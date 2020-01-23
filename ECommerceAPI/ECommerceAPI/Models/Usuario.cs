
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int IdPerfil { get; set; }
        public DateTime DataModificacao { get; set; }
        public Perfil Perfil { get; set; }

        [JsonIgnore]
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}