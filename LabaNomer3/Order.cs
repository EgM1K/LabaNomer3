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

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
            TotalAmount += dish.Price;
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
        public static Order CreateOrder(Client client, Restaurant chosenRestaurant)
        {
            Order order = new Order(new List<Dish>(), chosenRestaurant, client);

            while (true)
            {
                var chosenDish = chosenRestaurant.ChooseDish();
                order.AddDish(chosenDish);

                Console.WriteLine("Вибрати ще одну страву? (1 - так, 2 - ні)");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        break;
                    case "2":
                        order.DisplayOrderDetails();
                        return order;
                    default:
                        Console.WriteLine("Невідома опція. Будь ласка, спробуйте ще раз.");
                        break;
                }
            }
        }

            public void UpdateStatus(string status)
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
