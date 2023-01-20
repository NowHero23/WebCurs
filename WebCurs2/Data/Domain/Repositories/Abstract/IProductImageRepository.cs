using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface IProductImageRepository
    {
        public IEnumerable<ProductImage> ProductImages { get; }
        public Task<List<ProductImage>> GetAllByProductIdAsync(long id);

        public Task CreateAsync(ProductImage entity);

        public ProductImage? GetById(long id);

        public Task SeveAsync(ProductImage entity);
        public Task DeleteAsync(ProductImage entity);
        public Task<ProductImage> GetMainImageByProductIdAsync(long id);

    }
}
