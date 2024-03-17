using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class Dish
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Dish(string name, string descriotion, double price)
        {
            Name = name;
            Description = descriotion;
            Price = price;
        }
    }
}
