using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Cadastro 
    {
        [DataMember]
        public int idUsuario { get; set; }

        public int idProduto { get; set; }
        public int quantidade { get; set; }
        public int idPedido { get; set; }

    }
     public class Pedido : BaseModel
    {

        [Required]
        public Usuario Usuario { get; set; }
        public double valorTotal { get; set; }
        public int idUsuario { get; set; }
        // public int idPedido { get; set; }



        // [DataMember]
        //public int idPedido { get; protected set; }
        //[Required]
        //public int quantidade { get; set; }
        //[Required]
        //public decimal valorTotal { get; set; }
        //[Required]
        //public int idVenda { get; set; }


        public List<ItensPedido> Itens { get; private set; } = new List<ItensPedido>();
    }
}
