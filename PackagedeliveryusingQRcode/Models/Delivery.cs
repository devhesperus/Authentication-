using System;
using System.Collections.Generic;

namespace PackagedeliveryusingQRcode.Models;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public int? DeliveryOrder { get; set; }

    public int? EmployeeId { get; set; }

    public string? DeliveryStatus { get; set; }

    public virtual Order? DeliveryOrderNavigation { get; set; }

    public virtual Employee? Employee { get; set; }
}
