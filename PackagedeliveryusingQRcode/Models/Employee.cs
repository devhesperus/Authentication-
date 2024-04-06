using System;
using System.Collections.Generic;

namespace PackagedeliveryusingQRcode.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeFullName { get; set; }

    public string? EmployeeLocation { get; set; }

    public string? EmployeeStatus { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
