using Microsoft.AspNetCore.Mvc;
using WebCurs2.Data.Domain.Repositories.Abstract;
using WebCurs2.Models;
using WebCurs2.ViewModels;

namespace WebCurs2.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IProductRepository _productRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IProductRepository productRep, ShopCart shopCart)
        {
            this._productRep = productRep;
            this._shopCart = shopCart;
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
