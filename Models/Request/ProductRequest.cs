﻿namespace WSCoffeeShop.Models.Request
{
    public class ProductRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }

        public short Stock { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        //public Brand Brand { get; set; }

        //public Category Category { get; set; }



        //public virtual Category Category { get; set; } 
        //public virtual ICollection<Category> Category { get; set; } = null!;

    }
}
