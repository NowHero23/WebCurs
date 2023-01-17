using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Drawing.Printing;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Models;

namespace WebCurs2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProdectImage> ProdectImages { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        
        public DbSet<Navigate> Navigates { get; set; }
        public DbSet<Option> Options { get; set; }
        
    }
    
}