using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        public IEnumerable<Product> Products { get; }

        public Product GetProductById(long id);

        public Task<bool> CreateAsync(Product product);

        public Task DeleteAsync(Product entity);
        public Task SeveAsync(Product entity);
    }
}
