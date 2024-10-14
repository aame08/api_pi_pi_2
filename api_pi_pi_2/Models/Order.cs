using System;
using System.Collections.Generic;

namespace api_pi_pi_2.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? DispatchDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public int PointId { get; set; }

    public int? UserId { get; set; }

    public int? Code { get; set; }

    public int OrderStatusId { get; set; }

    public virtual Orderstatus OrderStatus { get; set; } = null!;

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual Point Point { get; set; } = null!;

    public virtual User? User { get; set; }
}
