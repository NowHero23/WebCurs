using Microsoft.EntityFrameworkCore;
using WebCurs2.Data;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.EntityFramework;

namespace WebCurs2.Models
{
    public class NavBar
    {
        private readonly ApplicationDbContext _context;
        public List<NavBarItem> NavBarParents { get; set; }

        public NavBar(ApplicationDbContext context)
        {
            _context = context;
            var rep = new EFNavigateRepository(context);

            NavBarParents = new List<NavBarItem>();
            foreach (var item in rep.GetParentsAsync().Result)
            {
                NavBarParents.Add(new NavBarItem(item, context));
            }
        }

        
    }
}
