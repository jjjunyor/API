using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Produto : BaseModel
    {
        //public Produto(int _idProduto)
        //{
        //    Id = _idProduto;
        //}
        //public Produto() {
        //}
     
        [Required]
        [DataMember]
        public string descricao { get; set; }
        [DataMember]
        [Required]
        public int qtdDisponivel { get; set; }
        [DataMember]
        [Required]
        public double PrecoUnitario { get; set; }

        public List<ItensPedido> Itens { get; private set; } = new List<ItensPedido>();
    }
}
