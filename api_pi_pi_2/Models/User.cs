using Newtonsoft.Json;

namespace api_pi_pi_2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int Role { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    [JsonIgnore]
    public virtual Role RoleNavigation { get; set; } = null!;
}
