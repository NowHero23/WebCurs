using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebCurs2.Data;
using WebCurs2.Data.Domain.Repositories.Abstract;
using WebCurs2.Data.Domain.Repositories.EntityFramework;
using WebCurs2.Models;
using WebCurs2.ViewModels;

namespace WebCurs2.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRep;
        private readonly ShopCart _shopCart;

        public CartController(IServiceProvider services)
        {
            var context = services.GetService<ApplicationDbContext>();
            _shopCart = new ShopCart(context);
            _productRep = new EFProductRepository(context);
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel { shopCart = _shopCart };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(long productId)
        {
            var item =_productRep.Products.FirstOrDefault(i=>i.Id== productId);
            if (item != null) 
            { 
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }


    }
}
