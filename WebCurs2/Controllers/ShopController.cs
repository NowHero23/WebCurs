using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using WebCurs2.Data;
using WebCurs2.Data.Domain.Repositories.Abstract;
using WebCurs2.Data.Domain.Repositories.EntityFramework;
using WebCurs2.Models;
using WebCurs2.ViewModels;

namespace WebCurs2.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository _productRep;
        private readonly ShopCart _shopCart;

        public ShopController(IServiceProvider services)
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

        
        public async Task<IActionResult> Details(long? id)
        {
            
            if (id == null) return NotFound();
            
            var model = _productRep.GetById(id);
            if (model == null) return NotFound();


            //ViewData["PreviousPageUrl"] = Request.HttpContext.Request.Path;
            return View("Details", model);
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
