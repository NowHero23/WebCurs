using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCurs2.Data;
using WebCurs2.Data.Domain.Repositories.Abstract;
using WebCurs2.Data.Domain.Repositories.EntityFramework;
using WebCurs2.Models;
using WebCurs2.ViewModels;

namespace WebCurs2.Views.Shared.Components.OffCanvasCart
{
    public class OffCanvasCartViewComponent : ViewComponent
    {
        private IProductRepository _productRep = new EFProductRepository(new Data.ApplicationDbContext(new DbContextOptions<Data.ApplicationDbContext>()));
        private ShopCart _shopCart;

        
        public OffCanvasCartViewComponent(IServiceProvider services)//ShopCart shopCart
        {
            //this._shopCart = shopCart;
            var context = services.GetService<ApplicationDbContext>();
            _shopCart = new ShopCart(context);
        }

        public IViewComponentResult Invoke()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel { shopCart = _shopCart };

            return View("Default", obj);
        }

    }
}
