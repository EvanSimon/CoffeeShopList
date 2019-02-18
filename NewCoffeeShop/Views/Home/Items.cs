using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCoffeeShop.Views.Home
{
    public class Items
    {
        
            public string ItemName { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }

        public Items(string itemName, string description, double price)
        {
            ItemName = itemName;
            Description = description;
            Price = price;
        }

        public Items()
        {
        }
    }
}