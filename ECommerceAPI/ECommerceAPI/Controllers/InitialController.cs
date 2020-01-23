using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Models;
using ECommerceAPI.Repository;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public InitialController(ECommerceDbContext context)
        {
            _produtoRepository = new ProdutoRepositoryImpl(context);
        }

        [HttpGet]
        public ActionResult Initiate()
        {
            _produtoRepository.Cadastrar(new Produto() { Nome = "TV Smart 32 4k", Preco = 1000.90m, Ativo = true, Descricao = "TV Smart 4K, 3 USBs, 3HDMI", DataModificacao = DateTime.Now });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Microondas LG", Preco = 399.78m, Ativo = true, Descricao = "Microondas LG", DataModificacao = DateTime.Now });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Fogão Brastemp", Preco = 899.99m, Ativo = true, Descricao = "Fogão Brastemp", DataModificacao = DateTime.Now });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Notebook Game Acer", Preco = 3800.00m, Ativo = true, Descricao = "Notebook Game Acer", DataModificacao = DateTime.Now });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Geladeira Samsung", Preco = 2850.25m, Ativo = false, Descricao = "Geladeira Samsung", DataModificacao = DateTime.Now });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Liquidificador Philco", Preco = 1000.90m, Ativo = false, Descricao = "Liquidificador Philco", DataModificacao = DateTime.Now });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Cama Box Baú King", Preco = 1500.00m, Ativo = true, Descricao = "Cama Box Baú King", DataModificacao = DateTime.Now });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Colchão King", Preco = 2200.89m, Ativo = true, Descricao = "Colchão King", DataModificacao = DateTime.Now });

            return Ok(new
            {
                Produtos = _produtoRepository.ListarTodos()
            });
        }
    }
}