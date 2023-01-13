using Microsoft.AspNetCore.Mvc;
using WebCurs2.ViewModels;

namespace WebCurs2.Views.Shared.Components.Product
{
    public class ProductViewComponent : ViewComponent
    {
        public ProductViewComponent()
        {
        }

        public IViewComponentResult Invoke(ProductViewModel model)
        {
            return View("Default", model);
        }
    }
}
