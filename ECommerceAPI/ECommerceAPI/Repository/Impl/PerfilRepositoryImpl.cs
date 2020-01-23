using ECommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    public class PerfilRepositoryImpl : PerfilRepository
    {
        private readonly ECommerceDbContext _context;
        public PerfilRepositoryImpl(ECommerceDbContext context)
        {
            _context = context;
        }
        public void Gravar(Perfil perfil)
        {
            if (!Exists(perfil))
            {
                _context.Perfis.Add(perfil);
                _context.SaveChanges();
            }
        }

        public List<Perfil> ListarTodos()
        {
            return _context.Perfis.ToList();
        }

        private bool Exists(Perfil perfil)
        {
            return _context.Perfis.Any(e => e.Nome == perfil.Nome);
        }
    }
}