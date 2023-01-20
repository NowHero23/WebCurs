using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCurs2.Data.Domain.Repositories.EntityFramework;
using WebCurs2.Data;
using WebCurs2.Models;
using WebCurs2.ViewModels;
using Microsoft.EntityFrameworkCore;
using WebCurs2.Data.Domain.Repositories.Abstract;

namespace WebCurs2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["PreviousPageUrl"] = Request.HttpContext.Request.Path;

            var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            PartsViewModel model = new PartsViewModel() {
                Products = new EFProductRepository(context),
                ProductCategories = new EFProductCategoryRepository(context),
                ProductRatings = new EFProductRatingRepository(context),
                ProductImages = new EFProductImageRepository(context)
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}