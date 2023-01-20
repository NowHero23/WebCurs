using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
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
        IEnumerable<Product> IProductRepository.Products => _context.Products.Include(prod=>prod.ProductCategory);

        private IIncludableQueryable<Product, ICollection<ProductRating>> _GetAllIncluded()
        {
            return _context.Products.OrderByDescending(o => o.Rating)
                                    .Include(prod => prod.ProductCategory)
                                    .Include(prod => prod.ProductImages)
                                    .Include(prod => prod.ProductRatings);
        }
        public async Task CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public List<Product> GetAll()
        {
            return _GetAllIncluded().ToList();
        }
        public Product? GetById(long? id)
        {
            if(id!=null) return _GetAllIncluded().FirstOrDefault(p => p.Id == id);
            return null;
        }
        public Product? GetBySKU(string SKU)
        {
            return _GetAllIncluded().FirstOrDefault(p => p.SKU == SKU);
        }
        public List<Product> GetProductsRange(int start=0, int end=8)
        {
            return _GetAllIncluded().ToList().GetRange(start, end);
        }

        public async Task SeveAsync(Product entity)
        {
            if (entity.Id == default)
                _context.Entry(entity).State = EntityState.Added;
            else
                _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public List<Product> GetNewProductsRange(int start, int end)
        {
            return _GetAllIncluded().Where(x => x.IsNew == true).ToList().GetRange(start, end);
        }

        public List<Product> GetFeaturedProductsRange(int start, int end)
        {
            return _GetAllIncluded().Where(x => x.IsNew == true || x.IsSale == true).ToList().GetRange(start, end);
        }

    }
}
