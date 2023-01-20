using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface IProductCategoryRepository
    {
        public IEnumerable<ProductCategory> ProductCategories { get; }
        public Task<List<ProductCategory>> GetAllByProductIdAsync(long id);

        public Task CreateAsync(ProductCategory entity);

        public ProductCategory? GetById(long id);
        public ProductCategory? GetByName(string name);

        public Task SeveAsync(ProductCategory entity);
        public Task DeleteAsync(ProductCategory entity);

    }
}
