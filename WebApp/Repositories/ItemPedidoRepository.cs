using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repositories.Contract;

namespace WebApp.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItensPedido>, IItemPediddoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

     
        public ItensPedido Add(ItensPedido itens)
        {

            // dbSet.Update(itens);
            dbSet.Update(itens);
          // dbSet.Attach(itens);
            contexto.SaveChanges();
            return itens;
        }
    }
}
