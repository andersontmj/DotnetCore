using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataModificacao { get; set; }
        public int IdProduto { get; set; }

        public virtual Produto Produto { get; set; }
        

    }
}
