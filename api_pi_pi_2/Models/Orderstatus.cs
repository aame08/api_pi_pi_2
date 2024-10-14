using System;
using System.Collections.Generic;

namespace api_pi_pi_2.Models;

public partial class Orderstatus
{
    public int OrderStatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
