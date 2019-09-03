using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ItensPedido: BaseModel

    {
       // public int idItemPedido { get; protected set; }
        
        //public ItensPedido(Pedido pedido, Produto produto, int quantidade, double precoUnitario)
        //{

        //    Pedido = pedido;
        //    Produto = produto;
        //    Quantidade = quantidade;
        //    PrecoUnitario = precoUnitario;
        //}
        //[Required]
        //public int idProduto { get; private set; }
        //[Required]
        public int idPedido { get; private set; }
        public int idProduto { get; private set; }


        [Required]
        public Pedido Pedido { get;  set; }
        [Required]
        public Produto Produto { get;  set; }
        [Required]
        public int Quantidade { get;  set; }
        //[Required]
        //public double PrecoUnitario { get; private set; }
    }
}
