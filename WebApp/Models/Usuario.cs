using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Usuario : BaseModel
    {
        [DataMember, Required]
        public string login { get; set; }

        [DataMember, Required]
        public string senha { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
