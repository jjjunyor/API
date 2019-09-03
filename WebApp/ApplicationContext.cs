using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produto>().ToTable("tblProduto");
            modelBuilder.Entity<Produto>().HasKey(t => t.Id);

            modelBuilder.Entity<ItensPedido>().ToTable("tblItemPedido");
            modelBuilder.Entity<ItensPedido>().HasKey(t => t.Id);




            modelBuilder.Entity<Pedido>().ToTable("tblPedido");
            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);

            modelBuilder.Entity<Pedido>().HasMany(h => h.Itens)
                .WithOne(w => w.Pedido)
                .HasForeignKey(k => k.idPedido)
                .HasPrincipalKey(p => p.Id);


            modelBuilder.Entity<Produto>().HasMany(h => h.Itens)
                .WithOne(w => w.Produto)
                .HasForeignKey(k => k.idProduto)
                .HasPrincipalKey(p => p.Id);

   

            modelBuilder.Entity<Usuario>().ToTable("tblUsuario");
            modelBuilder.Entity<Usuario>().HasKey(t => t.Id);




            modelBuilder.Entity<Usuario>().HasOne(t => t.Pedido).WithOne(f => f.Usuario)
        .HasForeignKey<Pedido>(x => new { x.idUsuario })
        .HasPrincipalKey<Usuario>(g => g.Id);

         
        }
    }
}
