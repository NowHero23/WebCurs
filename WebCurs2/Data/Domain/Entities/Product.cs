using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCurs2.Data.Domain.Entities
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

        [DefaultValue(0)]
        public double OldPrice { get; set; }


        [Required]
        [ForeignKey("ProductCategory")]
        public long ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        [Required]
        public long Count { get; set; }
        
        public string SKU { get; set; }


        [ForeignKey("ProductId")]
        public ICollection<ProductImage> ProductImages { get; set; }


        [ForeignKey("ProductId")]
        public ICollection<ProductRating> ProductRatings { get; set; }

        
        public double? Rating { get; set; }
    }

}
