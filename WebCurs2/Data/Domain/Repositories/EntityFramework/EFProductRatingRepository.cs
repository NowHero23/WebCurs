using Microsoft.EntityFrameworkCore;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.Abstract;

namespace WebCurs2.Data.Domain.Repositories.EntityFramework
{
    public class EFProductRatingRepository : IProductRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public EFProductRatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        IEnumerable<ProductRating> IProductRatingRepository.ProductRatings => _context.ProductRatings;

        public async Task CreateAsync(ProductRating entity)
        {
            await _context.ProductRatings.AddAsync(entity);
        }

        public async Task DeleteAsync(ProductRating entity)
        {
            _context.ProductRatings.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductRating>> GetAllByProductIdAsync(long id)
        {
            return await _context.ProductRatings.Where(n => n.Id == id).ToListAsync();
        }

        public ProductRating? GetById(long id)
        {
            return _context.ProductRatings.FirstOrDefault(n => n.Id == id);
        }

        public double? GetRatingByProductId(long id)
        {
            var list = _context.ProductRatings.Where(n => n.Id == id).ToListAsync().Result;

            if (list==null || list.Count==0)
                return null;

            double num = list.Sum(item => item.Rating) / list.Count();

            if (num==0)
                return null;
            
            return num/ list.Count;
        }

        public async Task SeveAsync(ProductRating entity)
        {
            if (entity.Id == default)
                _context.Entry(entity).State = EntityState.Added;
            else
                _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
