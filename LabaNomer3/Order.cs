using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public enum OrderStatus
    {
        Created,
        InProgress,
        Completed,
        Delivered,
        NotDelivered
    }
    public class Order
    {
        public OrderStatus Status { get; set; }
        public List<Dish> Dishes { get; set; }
        public double TotalAmount { get; set; }
        public Restaurant Restaurant { get; set; }
        public Courier Courier { get; set; }
        public Client Client { get; set; }

        public Order(List<Dish> dishes, Restaurant restaurant, Client client)
        {
            Dishes = dishes;
            TotalAmount = CalculateTotalAmount();
            Status = OrderStatus.InProgress;
            Restaurant = restaurant;
            Client = client;
        }

        public void DisplayTotalCaloriesAndPrice()
        {
            int totalCalories = Dishes.Sum(dish => dish.Calories);
            Console.WriteLine($"Загальна калорійність: {totalCalories}");
            Console.WriteLine($"Загальна ціна: {TotalAmount}");
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

            public void UpdateStatus(OrderStatus status)
        {
            Status = status;
        }
        public void DisplayOrderDetails()
        {
            Console.WriteLine($"Замовник: {Client.Name}");
            Console.WriteLine($"Адреса доставки: {Client.DeliveryAddress}");
            Console.WriteLine($"Контактний номер: {Client.ContactNumber}");
            Console.WriteLine($"Ресторан: {Restaurant.Name}");
            Console.WriteLine($"Статус замовлення: {Status}");
            DisplayTotalCaloriesAndPrice();
        }
    }
}
