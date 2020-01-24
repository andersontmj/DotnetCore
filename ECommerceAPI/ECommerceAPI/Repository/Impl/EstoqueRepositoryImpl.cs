using ECommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository.Impl
{
    public class EstoqueRepositoryImpl : EstoqueRepository
    {
        private readonly ECommerceDbContext _context;

        public EstoqueRepositoryImpl(ECommerceDbContext context)
        {
            _context = context;
        }
    }
}
