using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCurs2.Data.Domain.Entities
{
    public class ProdectImage
    {
        public long Id { get; set; }

        [Required]
        public string Url { get; set; }
        public string alt { get; set; }

        [Required]
        public long ProdectId { get; set; }

        [Required]
        [DefaultValue(0)]
        public long Rating { get; set; }
    }
}
