using WebCurs2.Models;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        public IEnumerable<Product> Products { get; }

        public Product GetProductById(int id);
    }
}
