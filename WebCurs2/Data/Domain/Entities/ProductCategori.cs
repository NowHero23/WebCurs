namespace WebCurs2.Data.Domain.Entities
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Count { get; set; }
        public string? Url { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
