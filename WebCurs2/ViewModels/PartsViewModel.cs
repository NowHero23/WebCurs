using WebCurs2.Data.Domain.Repositories.Abstract;

namespace WebCurs2.ViewModels
{
    public class PartsViewModel
    {
        public IOptionRepository Options { get; internal set; }
        public INavigateRepository Navigates { get; internal set; }

        public IProductRepository Products { get; internal set; }
        public IProductCategoryRepository ProductCategories { get; internal set; }
        public IProductImageRepository ProductImages { get; internal set; }
        public IProductRatingRepository ProductRatings { get; internal set; }
        

    }
}
