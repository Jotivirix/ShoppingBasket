using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    public class ShoppingItem
    {
        public string? Name { get; set; }

        public double UnitWeight { get; set; }

        public double Units { get; set; }

        public double TotalWeight { get; set; }

        public ShoppingItem() { }

        public ShoppingItem(string? name, double weight, double units)
        {
            Name = name;
            UnitWeight = weight;
            Units = units;
            TotalWeight = units * weight;
        }

    }
}
