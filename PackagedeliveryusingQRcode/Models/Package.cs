using System;
using System.Collections.Generic;

namespace PackagedeliveryusingQRcode.Models;

public partial class Package
{
    public int PackageId { get; set; }

    public int? Packages { get; set; }

    public double? Price { get; set; }

    public string? DeliveryLocation { get; set; }

    public DateOnly? Orderdate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
