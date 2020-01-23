using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    public class UsuarioRepositoryImpl : UsuarioRepository
    {
        private readonly ECommerceDbContext _context;
        public UsuarioRepositoryImpl(ECommerceDbContext context)
        {
            _context = context;
        }

        public Usuario BuscaPorLoginEmailSenha(string login, string email, string senha)
        {
            return _context.Usuarios.Include(u => u.Perfil).Where(u => u.Senha == senha
                    && (u.Login == login || u.Email == email)).FirstOrDefault();
        }

        public void Gravar(Usuario usuario)
        {
            if (!Exists(usuario))
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
        }

        public List<Usuario> ListarTodos()
        {
            return _context.Usuarios.Include(u => u.Perfil).ToList();
        }

        public Usuario SelecionarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        private bool Exists(Usuario usuario)
        {
            return _context.Usuarios.Any(e => e.Nome == usuario.Nome);
        }
    }
}