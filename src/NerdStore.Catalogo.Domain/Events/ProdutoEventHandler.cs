using MediatR;
using NerdStore.Catalogo.Domain.Services;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoEventHandler(IProdutoRepository produtoRepository, IEstoqueService estoqueService, IMediatorHandler mediatorHandler)
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            // Enviar um e-mail para aquisicao de mais produtos.
        }

        public async Task Handle(PedidoIniciadoEvent mensagem, CancellationToken cancellationToken)
        {
            var resultado = await _estoqueService.DebitarListaProdutosPedido(mensagem.ProdutosPedido);

            if (resultado)
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(mensagem.PedidoId, mensagem.ClienteId, mensagem.Total, mensagem.ProdutosPedido, mensagem.NomeCartao, mensagem.NumeroCartao, mensagem.ExpiracaoCartao, mensagem.CVVCartao));
            }
            else
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(mensagem.PedidoId, mensagem.ClienteId));
            }
        }
    }
}
