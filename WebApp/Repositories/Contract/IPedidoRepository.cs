using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories.Contract
{
   
    public interface IPedidoRepository
    {

        object GetPedido(int pedido = 0, int cdUsuario = 0);
        Pedido Add(Pedido pedido);
        Pedido GetPedidobyID(int pedido);
    }
}
