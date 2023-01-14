using Microsoft.EntityFrameworkCore;
using WebCurs2.Data.Domain.Repositories.Abstract;
using WebCurs2.Models;

namespace WebCurs2.Data.Domain.Repositories.EntityFramework
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        IEnumerable<Product> IProductRepository.Products => _context.Products;

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
