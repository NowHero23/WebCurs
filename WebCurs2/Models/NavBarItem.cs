using Microsoft.EntityFrameworkCore;
using WebCurs2.Data;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.Abstract;
using WebCurs2.Data.Domain.Repositories.EntityFramework;

namespace WebCurs2.Models
{
    public class NavBarItem
    {
        public Navigate navigate { get; set; }

        public List<NavBarItem> Childrens { get; set; } = null;


        public NavBarItem(Navigate navigate, ApplicationDbContext context)
        { 
            this.navigate = navigate;

            List<Navigate> arr =new EFNavigateRepository(context).GetChildrensByParentIdAsync(navigate.Id).Result;
            Childrens = new List<NavBarItem>();
            
            foreach (Navigate el in arr)
            {
                Childrens.Add(new NavBarItem(el, context));
            }

        }
    }
}
