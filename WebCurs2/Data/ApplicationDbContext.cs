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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-80RCMED; Database=WebCurs2; User ID='sa'; Password='sa';Trusted_Connection=True;MultipleActiveResultSets=true;encrypt=false");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Navigate> Navigates { get; set; }
        public DbSet<Option> Options { get; set; }
        
    }
    
}