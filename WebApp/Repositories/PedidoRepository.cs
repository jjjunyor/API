using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repositories.Contract;

namespace WebApp.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public object GetPedido(int pedido=0, int cdUsuario=0)
        {

            var pedidos = dbSet
               .Include(p => p.Itens)
                   .ThenInclude(i => i.Produto).Select(x=>new {
                       idUsuario = x.Usuario.Id,
                       login=x.Usuario.login,
                       pedidoformatado = string.Format("PED-{0}", x.Id.ToString().PadLeft(6, '0')),
                      idPedido = x.Id,
                      
                      Preco = x.valorTotal
                   })
               .Where(p => p.idUsuario == cdUsuario && (p.idPedido == pedido) || (0 == pedido))
               .ToList();

            return pedidos;
        }
        public Pedido GetPedidobyID(int pedido )
        {

            var pedidos = dbSet
               .Include(p => p.Itens)
                   .ThenInclude(i => i.Produto)
               .Where(p => p.Id == pedido).FirstOrDefault();
              

            return pedidos;
        }

        public Pedido Add(Pedido pedido)
        {

   
            dbSet.Attach(pedido);

            contexto.SaveChanges();

            return null; 
        }
    }
}
