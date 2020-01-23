using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}