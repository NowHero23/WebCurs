namespace WebCurs2.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsSale { get; set; }

        public string Category { get; set; }
        public string CategoryLink { get; set; }

        public string ImgSrc { get; set; }

        public int? DiscountPercentage { get; set; }

        public double? OldPrice { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
    }
}