using ECommerceAPI.Models;
using ECommerceAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueRepository _estoqueRepository;

        public EstoqueController(ECommerceDbContext context)
        {
            _estoqueRepository = new EstoqueRepositoryImpl(context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estoque>> Listar()
        {
            return _estoqueRepository.ListarTodos();
        }

        [HttpGet("{id}")]
        public ActionResult<Estoque> SelecionarPorId(int id)
        {
            return _estoqueRepository.SelecionarPorId(id);
        }

        [HttpPost]
        public ActionResult<Estoque> Salvar(Estoque estoque)
        {
            estoque.DataModificacao = DateTime.Now;
            _estoqueRepository.Cadastrar(estoque);

            return Created("api/[controller]", estoque);
        }

        [HttpPut("{id}")]
        public ActionResult<Estoque> Atualizar(int id, Estoque estoque)
        {
            if (id != estoque.Id)
            {
                return NotFound("Id e Produto informados, não são compatíveis");
            }

            _estoqueRepository.Atualizar(estoque);

            return Ok(estoque);
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            _estoqueRepository.Remover(id);
            return Ok("estoque removido com sucesso");
        }
    }
}
