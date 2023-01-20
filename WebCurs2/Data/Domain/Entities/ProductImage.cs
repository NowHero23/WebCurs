using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCurs2.Data.Domain.Entities
{
    public class ProductImage
    {
        public long Id { get; set; }

        [Required]
        public string Url { get; set; }
        public string Alt { get; set; }

        
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }


        [Required]
        [DefaultValue(0)]
        public long OrderId { get; set; }
    }
}
