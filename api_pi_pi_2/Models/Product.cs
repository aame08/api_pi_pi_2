using Newtonsoft.Json;

namespace api_pi_pi_2.Models;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Measure { get; set; } = null!;

    public decimal Cost { get; set; }

    public string? Description { get; set; }

    public int ProductTypeId { get; set; }

    public string? Photo { get; set; }

    public int SupplierId { get; set; }

    public int? ProductMaxDiscount { get; set; }

    public int ManufacturerId { get; set; }

    public int? CurrentDiscount { get; set; }

    public string Status { get; set; } = null!;

    public int QuantityInStock { get; set; }
    [JsonIgnore]
    public virtual Manufacturer Manufacturer { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual Producttype ProductType { get; set; } = null!;
    [JsonIgnore]
    public virtual Supplier Supplier { get; set; } = null!;
}
