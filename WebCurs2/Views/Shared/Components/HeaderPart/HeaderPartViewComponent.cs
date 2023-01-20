using Microsoft.AspNetCore.Mvc;
using WebCurs2.Data;
using WebCurs2.ViewModels;
using WebCurs2.Data.Domain.Repositories.EntityFramework;
using WebCurs2.Data.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Models;
using NuGet.Packaging;

namespace WebCurs2.Views.Shared.Components.HeaderPartViewComponent
{
    public class HeaderPartViewComponent : ViewComponent
    {
        private ApplicationDbContext _context;
        private IOptionRepository _optRep { get; set; }
        
        public HeaderPartViewComponent(IServiceProvider services)
        {
            _context = services.GetRequiredService<ApplicationDbContext>();

            _optRep = new EFOptionRepository(_context);
        }

        public IViewComponentResult Invoke()
        {
            return View("Default", new PartsViewModel { Options = _optRep });
        }
    }
}
