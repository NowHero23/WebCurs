using Microsoft.EntityFrameworkCore;
using WebCurs2.Data;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Models
{
    public class ShopCart
    {
        private readonly ApplicationDbContext _context;
        public ShopCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
    

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Product product, long count=1)
        {
            ShopCartItem? tmp = _context.ShopCartItems.Where(item => item.product == product && item.ShopCartId == ShopCartId).FirstOrDefault();

            if (tmp != null)
            {
                tmp.Count += count;
                _context.Update(tmp);
            }
            else
            {
                _context.ShopCartItems.Add(new ShopCartItem
                {
                    ShopCartId = ShopCartId,
                    product = product,
                    Count = count
                });
            }

            _context.SaveChangesAsync();
        }
        public List<ShopCartItem> GetShopItems()
        {
            return _context.ShopCartItems.Where(c =>c.ShopCartId== ShopCartId).Include(s=>s.product).ToList();
        }

        public void RemoveCart(Product product, long count = 1)
        {
            ShopCartItem? tmp = _context.ShopCartItems.Where(item => item.product == product && item.ShopCartId == ShopCartId).FirstOrDefault();

            if (tmp.Count == count)
            {
                _context.ShopCartItems.Remove(tmp);
            }
            else
            {
                tmp.Count-= count;
                _context.Update(tmp);
            }

            _context.SaveChangesAsync();
        }

    }
}
