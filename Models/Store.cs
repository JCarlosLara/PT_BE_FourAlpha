using System;
using System.Collections.Generic;

namespace WSCoffeeShop.Models;

public partial class Store
{
    public int Id { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }
}
