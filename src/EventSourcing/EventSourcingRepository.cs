﻿using EventStore.ClientAPI;
using NerdStore.Core.Data.EventSourcing;
using NerdStore.Core.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        private readonly IEventStoreService _eventStoreService;

        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        public async Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            await _eventStoreService.GetConnection().AppendToStreamAsync(
                    evento.AggregateId.ToString(),
                    ExpectedVersion.Any,
                    FormatarEvento(evento)
                );
        }

        public async Task<IEnumerable<StoredEvent>> ObterEventos(Guid aggregateId)
        {
            var eventos = await _eventStoreService.GetConnection()
                .ReadStreamEventsForwardAsync(aggregateId.ToString(), 0, 500, false);

            var listaEventos = new List<StoredEvent>();

            foreach (var resolvedEvent in eventos.Events)
            {
                var data = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                var json = JsonConvert.DeserializeObject<BaseEvent>(data);

                var evento = new StoredEvent(
                    resolvedEvent.Event.EventId,
                    resolvedEvent.Event.EventType,
                    json.Timestamp,
                    data
                );

                listaEventos.Add(evento);
            }

            return listaEventos;
        }

        private static IEnumerable<EventData> FormatarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            yield return new EventData(
                Guid.NewGuid(),
                evento.MessageType,
                true,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evento)),
                null
            );
        }

    }
}
