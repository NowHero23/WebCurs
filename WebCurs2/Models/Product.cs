using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCurs2.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }


        [DefaultValue(true)]
        public bool IsNew { get; set; }
        [DefaultValue(false)]
        public bool IsSale { get; set; }


        [Required]
        [DefaultValue(0)]
        public int DiscountPercentage { get; set; }
        [Required]
        public double Price { get; set; }
        public double? OldPrice { get; set; }


        [Required]
        public long CategoryId { get; set; }

        public string ImgSrc { get; set; }
        public string ImgAlt { get; set; }

        [Required]
        [DefaultValue(0)]
        public long Count { get; set; }

        public string SKU { get; set; }
    }

}
