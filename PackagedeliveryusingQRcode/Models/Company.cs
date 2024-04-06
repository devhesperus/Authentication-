using System;
using System.Collections.Generic;

namespace PackagedeliveryusingQRcode.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyLocation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
