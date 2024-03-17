using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class Order
    {
        public List<Dish> Dishes { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public Restaurant Restaurant { get; set; }
        public Courier Courier { get; set; }
        public Client Client { get; set; }
        public Order(List<Dish> dishes, Restaurant restaurant, Client client)
        {
            Dishes = dishes;
            TotalAmount = CalculateTotalAmount();
            Status = "Виконано";
            Restaurant = restaurant;
            Client = client;
        }

        private double CalculateTotalAmount()
        {
            double total = 0;
            foreach (var dish in Dishes)
            {
                total += dish.Price;
            }
            return total;
        }
        public void UpdateStatus(string status)
        {
            Status = status;
        }
    }
}
