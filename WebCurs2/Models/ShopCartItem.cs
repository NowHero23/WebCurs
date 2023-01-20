using System.ComponentModel.DataAnnotations.Schema;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Models
{
    public class ShopCartItem
    {
        public long Id { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long Count { get; set; } = 1;

        public string ShopCartId { get; set; }

    }
}
