using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCurs2.Data;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.Abstract;
using WebCurs2.Data.Domain.Repositories.EntityFramework;
using WebCurs2.Models;
using WebCurs2.ViewModels;

namespace WebCurs2.Views.Shared.Components.BreadCrumb
{
    public class BreadCrumbViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private INavigateRepository _navRep { get; set; }


        public BreadCrumbViewComponent(IServiceProvider services)
        {
            _context = services.GetRequiredService<ApplicationDbContext>();

            _navRep = new EFNavigateRepository(_context);
        }


        public IViewComponentResult Invoke(BreadCrumbViewModel obj)
        {
            obj.NavPoints = new List<Navigate>();
            Navigate cursor = obj.endPoint;
            while (cursor.ParentId!=null)
            {
                var tmp = _navRep.GetById((long)cursor.ParentId);
                if (tmp!=null)
                {
                    obj.NavPoints.Add(tmp);
                }
                cursor = obj.NavPoints.Last();
            }
            obj.NavPoints.Reverse();
            obj.Navigates = new EFNavigateRepository(_context);
            obj.Options = new EFOptionRepository(_context);
            return View("Default", obj);
        }

    }
}
