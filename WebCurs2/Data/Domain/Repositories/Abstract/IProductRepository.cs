using System.Linq.Expressions;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        public IEnumerable<Product> Products { get; }

        public List<Product> GetAll();
        public Product? GetById(long? id);
        public Product? GetBySKU(string SKU);


        public List<Product> GetProductsRange(int start, int end);
        public List<Product> GetNewProductsRange(int start, int end);
        public List<Product> GetFeaturedProductsRange(int start, int end);



        public Task CreateAsync(Product product);

        public Task DeleteAsync(Product entity);
        public Task SeveAsync(Product entity);
    }
}
