using Microsoft.EntityFrameworkCore;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.Abstract;

namespace WebCurs2.Data.Domain.Repositories.EntityFramework
{
    public class EFProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public EFProductCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        IEnumerable<ProductCategory> IProductCategoryRepository.ProductCategories => _context.ProductCategories;

        public async Task CreateAsync(ProductCategory entity)
        {
            await _context.ProductCategories.AddAsync(entity);
        }

        public async Task DeleteAsync(ProductCategory entity)
        {
            _context.ProductCategories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductCategory>> GetAllByProductIdAsync(long id)
        {
            return await _context.ProductCategories.Where(n => n.Id == id).ToListAsync();
        }

        public ProductCategory? GetById(long id)
        {
            return _context.ProductCategories.FirstOrDefault(n => n.Id == id);
        }

        public ProductCategory? GetByName(string name)
        {
            return _context.ProductCategories.FirstOrDefault(n => n.Name == name);
        }

        public async Task SeveAsync(ProductCategory entity)
        {
            if (entity.Id == default)
                _context.Entry(entity).State = EntityState.Added;
            else
                _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
