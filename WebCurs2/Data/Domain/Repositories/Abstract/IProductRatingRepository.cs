using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface IProductRatingRepository
    {
        public IEnumerable<ProductRating> ProductRatings { get; }
        public Task<List<ProductRating>> GetAllByProductIdAsync(long id);

        public double? GetRatingByProductId(long id);

        public Task CreateAsync(ProductRating entity);

        public ProductRating? GetById(long id);

        public Task SeveAsync(ProductRating entity);
        public Task DeleteAsync(ProductRating entity);

    }
}
