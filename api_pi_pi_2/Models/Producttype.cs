using Newtonsoft.Json;

namespace api_pi_pi_2.Models;

public partial class Producttype
{
    public int ProductTypeId { get; set; }

    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
