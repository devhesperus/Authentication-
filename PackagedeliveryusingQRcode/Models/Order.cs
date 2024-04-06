using System;
using System.Collections.Generic;

namespace PackagedeliveryusingQRcode.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? Packages { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public string? OrderStatus { get; set; }

    public int? DeliveryPartner { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Company? DeliveryPartnerNavigation { get; set; }

    public virtual Package? PackagesNavigation { get; set; }
}
