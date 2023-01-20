using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebCurs2.Data;
using WebCurs2.Data.Domain.Repositories.EntityFramework;
using WebCurs2.Models;

namespace WebCurs2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;


        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(
                opt =>
                {
                    opt.Password.RequireDigit = true;
                    opt.Password.RequiredLength = 8;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequireNonAlphanumeric = false;

                    opt.Lockout.MaxFailedAccessAttempts = 5;

                    opt.User.RequireUniqueEmail = true;

                    opt.SignIn.RequireConfirmedEmail = true;                   
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));


            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();


            CultureInfo cultureInfo = new CultureInfo(new EFOptionRepository(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>())).GetByName("CultureInfo").Value);
            cultureInfo.NumberFormat.CurrencySymbol = "$";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
