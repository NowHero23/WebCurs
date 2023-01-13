using Microsoft.AspNetCore.Mvc;
using WebCurs2.Data;
using WebCurs2.ViewModels;
using WebCurs2.Data.Domain.Repositories.EntityFramework;
using WebCurs2.Data.Domain.Repositories.Abstract;
using WebCurs2.Models;

namespace WebCurs2.Views.Shared.Components.Product
{
    public class NavBarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public NavBarViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string type = "Desctop")
        {
            INavigateRepository repository = new EFNavigateRepository(_context);

            List<Navigate> model = repository.GetAllAsync().Result;


            if (type == "Offcanvas")
                return View("Offcanvas", model);     
            else
                return View("Desctop", model);
        }
    }
}
