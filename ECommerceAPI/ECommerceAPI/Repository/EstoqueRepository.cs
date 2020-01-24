using ECommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    interface EstoqueRepository
    {
        interface ProdutoRepository
        {
            void Cadastrar(Estoque estoque);
            void Atualizar(Estoque estoque);
            void Remover(int id);
            Estoque SelecionarPorId(int id);
            List<Estoque> ListarTodos();
        }
    }
}
