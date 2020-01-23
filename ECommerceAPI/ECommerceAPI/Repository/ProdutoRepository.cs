using ECommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    interface ProdutoRepository
    {
        void Cadastrar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(int id);
        Produto SelecionarPorId(int id);
        List<Produto> ListarTodos();
        List<Produto> ListarTodosAtivos();
    }
}