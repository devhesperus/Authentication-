using System;
using System.Collections.Generic;

namespace PackagedeliveryusingQRcode.Models;

public partial class Authentication
{
    public string UserId { get; set; } = null!;

    public string? Jwttoken { get; set; }

    public string? Roles { get; set; }
}
