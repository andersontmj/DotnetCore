using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    class ProdutoRepositoryImpl : ProdutoRepository
    {
        private readonly ECommerceDbContext _context;
        public ProdutoRepositoryImpl(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Atualizar(Produto produto)
        {
           if(ProdutoExists(produto.Id))
            {
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Cadastrar(Produto produto)
        {
            if (!ProdutoExists(produto))
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
            }
        }

        public List<Produto> ListarTodos()
        {
            return SelecionarDadosEspecificos(_context.Produtos.Include(p => p.UsuarioCriador));
        }

        public List<Produto> ListarTodosAtivos()
        {
            return SelecionarDadosEspecificos(_context.Produtos.Include(p => p.UsuarioCriador).Where(p => p.Ativo == true));
        }

        public void Remover(int id)
        {
            var produto = SelecionarPorId(id);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public Produto SelecionarPorId(int id)
        {
            return _context.Produtos.Find(id);
        }

        private bool ProdutoExists(Produto produto)
        {
            return _context.Produtos.Any(e => e.Nome == produto.Nome);
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }

        private List<Produto> SelecionarDadosEspecificos(IQueryable<Produto> query)
        {
            return query.Select(r => new Produto()
            {
                Ativo = r.Ativo,
                DataModificacao = r.DataModificacao,
                Descricao = r.Descricao,
                Id = r.Id,
                IdUsuario = r.IdUsuario,
                Nome = r.Nome,
                Preco = r.Preco,
                UsuarioCriador = new Usuario()
                {
                    Nome = r.UsuarioCriador.Nome,
                    Login = r.UsuarioCriador.Login,
                }
            }).ToList();
        }
    }
}
