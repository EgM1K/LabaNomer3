using System;
using System.Collections.Generic;

namespace LabaNomer3
{
    public enum RestaurantName
    {
        McDonalds = 1,
        KFC = 2,
        BurgerKing = 3,
        Subway = 4,
        Starbucks = 5,
        PizzaHut = 6,
        Dominos = 7,
        Dunkin = 8,
        BaskinRobbins = 9,
        Custom = 10
    }

    public enum RestaurantType
    {
        FastFood = 1,
        CasualDining = 2,
        CoffeeShop = 3,
        IceCreamParlor = 4,
        PizzaPlace = 5,
    }

    public class Restaurant
    {
        public RestaurantName Name { get; set; }
        public RestaurantType Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Rating { get; set; }
        public List<Dish> Menu { get; set; }

        private static List<string> addresses = new List<string>
        {
            "Вулиця Шевченка",
            "Вулиця Гетеросексуалів",
            "Проспект Незалежності",
            "Вулиця Соборна",
            "Вулиця Підорасів",
            "Вулиця Лесі Українки",
            "Вулиця Тараса Шевченка",
            "Вулиця Михайла Грушевського",
            "Вулиця Степана Бандери",
            "Проспект Перемоги",
            "Вулиця Франка",
            "Вулиця Старий міст",
            "Вулиця Польова",
            "Вулиця Шевченка",
            "Проспект Миру",
            "Вулиця Грушевського",
            "Вулиця Київська",
            "Вулиця Героїв Майдану",
            "Проспект Свободи",
            "Вулиця Івана Франка",
            "Вулиця Ткалича",
            "Вулиця Лермонтова",
            "Вулиця Шевченка",
            "Вулиця Сліпого",
            "Проспект Лесі Українки",
            "Вулиця Короленка",
            "Вулиця Пасхаліна",
            "Вулиця Міцкевича",
            "Вулиця Київська",
            "Проспект Ілліча"
        };

        public Restaurant(RestaurantName name, RestaurantType type, string city)
        {
            Name = name;
            Type = type;
            City = city;
            Rating = GenerateRandomRating();
            Address = GenerateRandomAddress();
            Menu = Dish.Dishes.Where(dish => dish.Type == type).ToList();
        }

        public static int GenerateRandomRating()
        {
            var random = new Random();
            return random.Next(2, 6);
        }

        public static string GenerateRandomAddress()
        {
            var random = new Random();
            int index = random.Next(addresses.Count);
            string address = addresses[index];
            int houseNumber = random.Next(1, 151);
            return address + ", " + houseNumber.ToString();
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Назва: {Name}, Тип: {Type}, Місто: {City}, Адреса: {Address}, Рейтинг: {Rating}");
        }
        

    }
}
