using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Models
{
    public class ShopCartItem
    {
        public long Id { get; set; }
        public Product product { get; set; }

        public long Count { get; set; } = 1;

        public string ShopCartId { get; set; }

    }
}
