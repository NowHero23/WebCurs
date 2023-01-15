using Microsoft.EntityFrameworkCore;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.Abstract;

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


        public async Task<bool> CreateAsync(Product product)
        {
            var tmp = _context.Products.AddAsync(product).IsCompletedSuccessfully;
            SeveAsync(product);
            return tmp;
        }

        public async Task DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Product? GetProductById(long id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public async Task SeveAsync(Product entity)
        {
            if (entity.Id == default)
                _context.Entry(entity).State = EntityState.Added;
            else
                _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
