using Microsoft.AspNetCore.Identity;
using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.EntityFramework;

namespace WebCurs2.Data
{
    public class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider provider)
        {
            var roleMgr = provider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var roleName in RoleNames.AllRoles)
            {
                var role = roleMgr.FindByNameAsync(roleName).Result;

                if (role == null)
                {
                    var result = roleMgr.CreateAsync(new IdentityRole { Name = roleName }).Result;
                    if (!result.Succeeded) throw new Exception(result.Errors.First().Description);
                }
            }

            var userMgr = provider.GetRequiredService<UserManager<IdentityUser>>();

            var adminResult = await userMgr.CreateAsync(DefaultUsers.Administrator, "zxc123QWE");
            var userResult = await userMgr.CreateAsync(DefaultUsers.User, "zxc123QWE");
            var moderatorResult = await userMgr.CreateAsync(DefaultUsers.Moderator, "zxc123QWE");

            if (adminResult.Succeeded || userResult.Succeeded || moderatorResult.Succeeded)
            {
                var adminUser = await userMgr.FindByEmailAsync(DefaultUsers.Administrator.Email);
                var commonUser = await userMgr.FindByEmailAsync(DefaultUsers.User.Email);
                var moderatorUser = await userMgr.FindByEmailAsync(DefaultUsers.Moderator.Email);

                await userMgr.AddToRoleAsync(adminUser, RoleNames.Administrator);
                await userMgr.AddToRoleAsync(commonUser, RoleNames.User);
                await userMgr.AddToRoleAsync(moderatorUser, RoleNames.Moderator);
            }



            var context = provider.GetService<ApplicationDbContext>();
            var navRep = new EFNavigateRepository(context);

            foreach (var el in DefaultNavigations.AllNavigations)
            {
                var nav = await navRep.GetByNameAsync(el.Name);
                    
                if (nav == null)
                {
                    try
                    {
                        await navRep.CreateAsync(el); 
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); 
                    }
                }
            }

            var optRep = new EFOptionRepository(context);
            foreach (var el in DefaultOptions.AllOptions)
            {
                var nav = await optRep.GetByNameAsync(el.Name);

                if (nav == null)
                {
                    try
                    {
                        await optRep.CreateAsync(el);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }

            context.SaveChanges();

            var prodCatRep = new EFProductCategoryRepository(context);
            foreach (var el in DefaultProductCategories.AllProductCategories)
            {
                ProductCategory? cat = prodCatRep.GetByName(el.Name);

                if (cat == null)
                {
                    await prodCatRep.CreateAsync(el);
                    await context.SaveChangesAsync();
                }
                cat = prodCatRep.GetByName(el.Name);
                Console.WriteLine(cat);
            }
            

            var imgRep = new EFProductImageRepository(context);
            foreach (var el in DefaultImages.AllProductImage)
            {
                var img = imgRep.GetByUrl(el.Url);

                if (img == null)
                {
                    await imgRep.CreateAsync(el);
                    await context.SaveChangesAsync();
                }
            }

            

            context.SaveChanges();
        }
    }

    public static class RoleNames
    {
        public const string Administrator = "Admin";
        public const string User = "User";
        public const string Moderator = "Moderator";

        public static IEnumerable<string> AllRoles
        {
            get
            {
                yield return Administrator;
                yield return User;
                yield return Moderator;
            }
        }
    }

    public static class DefaultUsers
    {
        public static readonly IdentityUser Administrator = new IdentityUser
        {
            Email = "Admin@test.com",
            EmailConfirmed = true,
            UserName = "Admin@test.com"
        };

        public static readonly IdentityUser Moderator = new IdentityUser
        {
            Email = "Moderator@test.com",
            EmailConfirmed = true,
            UserName = "Moderator@test.com",
        };

        public static readonly IdentityUser User = new IdentityUser
        {
            Email = "User@test.com",
            EmailConfirmed = true,
            UserName = "User@test.com"
        };

        public static IEnumerable<IdentityUser> AllUsers
        {
            get
            {
                yield return Administrator;
                yield return Moderator;
                yield return User;
            }
        }
    }

    public static class DefaultNavigations
    {
        public static readonly Navigate Home = new Navigate
        {
            Name = "Home",
            Url = "/",
            ParentId = null,
            OrderId = 0,
        };
        public static readonly Navigate About = new Navigate
        {
            Name = "About",
            Url = "/About/",
            ParentId = null,
            OrderId = 1,
        };
        public static readonly Navigate Catalog = new Navigate
        {
            Name = "Catalog",
            Url = "/Catalog/",
            ParentId = null,
            OrderId = 2,
        };
        public static readonly Navigate Blog = new Navigate
        {
            Name = "Blog",
            Url = "/Blog/",
            ParentId = null,
            OrderId = 3,
        };
        public static readonly Navigate Contact = new Navigate
        {
            Name = "Contact",
            Url = "/Contact/",
            ParentId = null,
            OrderId = 4,
        };
        public static readonly Navigate FAQ = new Navigate
        {
            Name = "FAQ",
            Url = "/FAQ/",
            ParentId = null,
            OrderId = 5,
        };

        public static IEnumerable<Navigate> AllNavigations
        {
            get
            {
                yield return Home;
                yield return About;
                yield return Catalog;
                yield return Blog;
                yield return Contact;
                yield return FAQ;
            }
        }
    }

    public static class DefaultOptions
    {
        public static readonly Option phone = new Option
        {
            Name = "Phone",
            Value = "0123456789",
        };
        public static readonly Option email = new Option
        {
            Name = "Email",
            Value = "demo@example.com",
        };
        public static readonly Option address = new Option
        {
            Name = "Address",
            Value = "Your Address Goes Here.",
        };
        public static readonly Option cultureInfo = new Option
        {
            Name = "CultureInfo",
            Value = "en-US",
        };
        

        public static IEnumerable<Option> AllOptions
        {
            get
            {
                yield return phone;
                yield return email;
                yield return address;
                yield return cultureInfo;
            }
        }
    }

    public static class DefaultProductCategories
    {
        public static readonly ProductCategory Category1 = new ProductCategory
        {
            Name = "Phone",
            Description = "Phone",
            Count = 0

        };
        public static readonly ProductCategory Category2 = new ProductCategory
        {
            Name = "Accessories",
            Description = "Accessories",
            Count = 0

        };

        public static IEnumerable<ProductCategory> AllProductCategories
        {
            get
            {
                yield return Category1;
                yield return Category2;
               
            }
        }
    }

    public static class DefaultProducts
    {
        public static readonly Product Product1 = new Product
        {
            Title = "Phone",
            Description = "Phone",
            IsNew = true,
            IsSale = false,
            DiscountPercentage = 0,
            Price = 100,
            OldPrice = -1,
            ProductCategoryId = 1,
            Count = 0,
            SKU = "1hg2-1"
        };
        

        public static IEnumerable<Product> AllProducts
        {
            get
            {
                yield return Product1;
                

            }
        }
    }
    public static class DefaultImages
    {
        public static readonly ProductImage img1 = new ProductImage
        {
            Url = @"/images/product-image/1.webp",
            Alt = "Default picture",
            ProductId = 1,
            OrderId= 1,
        };


        public static IEnumerable<ProductImage> AllProductImage
        {
            get
            {
                yield return img1;


            }
        }
    }
    
}
