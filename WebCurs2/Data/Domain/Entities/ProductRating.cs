using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCurs2.Data.Domain.Entities
{
    public class ProductRating
    {
        public long Id { get; set; }

        [Required]
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        [MaxLength(1)]
        public int Rating { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
