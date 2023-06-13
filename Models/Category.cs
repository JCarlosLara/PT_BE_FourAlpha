using System;
using System.Collections.Generic;

namespace WSCoffeeShop.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    //public List<Product> Productos { get; set; }
}
