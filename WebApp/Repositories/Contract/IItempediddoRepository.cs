using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories.Contract
{

        public interface IItemPediddoRepository
        {
        ItensPedido Add(ItensPedido itens);
        }
    
}
