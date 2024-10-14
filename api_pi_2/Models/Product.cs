using System.ComponentModel.DataAnnotations.Schema;

namespace api_pi_2.Models
{
    public class Product
    {
        public string ProductArticleNumber { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Measure { get; set; } = null!;

        public decimal Cost { get; set; }

        public string? Description { get; set; }

        public int ProductTypeId { get; set; }

        public string? Photo { get; set; }
        [NotMapped]
        public string DisplayedPhoto
        {
            get
            {
                if (string.IsNullOrEmpty(Photo))
                {
                    return "pack://application:,,,/Resources/picture.png";
                }
                else
                {
                    return $"pack://application:,,,/Resources/{Photo}";
                }
            }
        }

        public int SupplierId { get; set; }

        public int? ProductMaxDiscount { get; set; }

        public int ManufacturerId { get; set; }

        public int? CurrentDiscount { get; set; }

        public string Status { get; set; } = null!;

        public int QuantityInStock { get; set; }

        public virtual Producttype ProductType { get; set; } = null!;
        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
    }
}
