using System;
using System.Linq;
using NerdStore.Core.Data;
using System.Threading.Tasks;
using NerdStore.Core.Messages;
using Microsoft.EntityFrameworkCore;
using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Data.Context
{
    public class VendasContext : DbContext, IUnitOfWork
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        public VendasContext(DbContextOptions<VendasContext> options)
            : base(options)
        {

        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                x => x.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            // Gerar um código de pedido sequencial
            modelBuilder.HasSequence<int>("MinhaSequencia").StartsAt(1000).IncrementsBy(1);
            base.OnModelCreating(modelBuilder);
        }

    }
}