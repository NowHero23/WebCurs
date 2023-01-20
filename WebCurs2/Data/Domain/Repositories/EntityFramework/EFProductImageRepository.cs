using Microsoft.EntityFrameworkCore;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.Abstract;

namespace WebCurs2.Data.Domain.Repositories.EntityFramework
{
    public class EFProductImageRepository : IProductImageRepository
    {
        private readonly ApplicationDbContext _context;
        public EFProductImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        IEnumerable<ProductImage> IProductImageRepository.ProductImages => _context.ProductImages;

        public async Task CreateAsync(ProductImage image)
        {
            await _context.ProductImages.AddAsync(image);
        }

        public async Task DeleteAsync(ProductImage entity)
        {
            _context.ProductImages.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductImage>> GetAllByProductIdAsync(long id)
        {
            return await _context.ProductImages.Where(n => n.ProductId == id).OrderBy(o=>o.OrderId).ToListAsync();
        }
        public async Task<ProductImage?> GetMainImageByProductIdAsync(long id)
        {
            return await _context.ProductImages.Where(n => n.ProductId == id).FirstOrDefaultAsync();
        }

        public ProductImage? GetById(long id)
        {
            return _context.ProductImages.FirstOrDefault(n => n.Id == id);
        }
        public ProductImage? GetByUrl(string url)
        {
            return _context.ProductImages.FirstOrDefault(n => n.Url == url);
        }

        public async Task SeveAsync(ProductImage entity)
        {
            if (entity.Id == default)
                _context.Entry(entity).State = EntityState.Added;
            else
                _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
