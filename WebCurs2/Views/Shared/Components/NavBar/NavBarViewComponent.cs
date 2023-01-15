using Microsoft.AspNetCore.Mvc;
using WebCurs2.Data;
using WebCurs2.ViewModels;
using WebCurs2.Data.Domain.Repositories.EntityFramework;
using WebCurs2.Data.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Models;
using NuGet.Packaging;

namespace WebCurs2.Views.Shared.Components.Product
{
    public class NavBarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private INavigateRepository _navRep { get; set; }
        

        public NavBarViewComponent(IServiceProvider services)
        {
            _context = services.GetRequiredService<ApplicationDbContext>();

            _navRep = new EFNavigateRepository(_context);
        }

        public IViewComponentResult Invoke(string type = "Desctop")
        {
            var model = new NavBarViewModel { NavBarItems = new List<NavBarItem>() };

            foreach (Navigate el in _navRep.GetParentsAsync().Result)
            {
                model.NavBarItems.Add(new NavBarItem(el, _context));
            }

            switch (type)
            {
                case "Mobil":
                    return View("Mobil", model);
                case "Desctop":
                    return View("Desctop", model);
                default:
                    break;
            }

            return View("Desctop", model);
        }
    }
}
