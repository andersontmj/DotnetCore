using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal? Preco { get; set; }
        [Required]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataModificacao { get; set; }
        public int IdUsuario { get; set; }
        public Usuario UsuarioCriador { get; set; }
        public virtual Estoque Estoque { get; set; }
    }
}