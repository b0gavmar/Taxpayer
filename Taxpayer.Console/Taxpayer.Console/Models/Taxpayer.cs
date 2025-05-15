using System;
using System.Collections.Generic;

namespace TaxpayerConsole.Models;

public partial class Taxpayer
{
    public string? Email { get; set; }

    public string? Name { get; set; }

    public int? Amount { get; set; }
}
