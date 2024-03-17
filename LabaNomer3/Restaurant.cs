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
            "Вулиця Гагаріна",
            "Проспект Незалежності",
            "Вулиця Соборна",
            "Вулиця Пушкіна",
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
            "Вулиця Миру",
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
        public void DisplayMenu()
        {
            Console.WriteLine("Меню:");
            foreach (var dish in Menu)
            {
                Console.WriteLine($"Назва: {dish.Name}, Опис: {dish.Description}, Ціна: {dish.Price}, Калорії: {dish.Calories}");
            }
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Назва: {Name}, Тип: {Type}, Місто: {City}, Адреса: {Address}, Рейтинг: {Rating}");
        }

        public static Restaurant ChooseRestaurant()
        {
            Console.WriteLine("Введіть місто:");
            string city = Console.ReadLine();

            Console.WriteLine("Виберіть ресторан: \n(1) McDonalds \n(2) KFC \n(3) BurgerKing \n(4) Subway \n(5) Starbucks \n(6) PizzaHut \n(7) Dominos \n(8) Dunkin \n(9) BaskinRobbins \n(10) Custom"); ;
            int chosenNumber = Int32.Parse(Console.ReadLine());

            if (chosenNumber < 1 || chosenNumber > 10)
            {
                Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                return ChooseRestaurant();
            }
            RestaurantName chosenName;
            RestaurantType chosenType;

            if (chosenNumber == 10)
            {
                Console.WriteLine("Введіть назву ресторану:");
                string customName = Console.ReadLine();
                chosenName = RestaurantName.Custom;

                Console.WriteLine("Виберіть тип ресторану: \n(1) FastFood \n(2) CasualDining \n(3) CoffeeShop \n(4) IceCreamParlor \n(5) PizzaPlace");
                int typeNumber = Int32.Parse(Console.ReadLine());
                chosenType = (RestaurantType)typeNumber;
            }
            else
            {
                chosenName = (RestaurantName)chosenNumber;
                switch (chosenName)
                {
                    case RestaurantName.McDonalds:
                    case RestaurantName.KFC:
                    case RestaurantName.BurgerKing:
                        chosenType = RestaurantType.FastFood;
                        break;
                    case RestaurantName.Starbucks:
                    case RestaurantName.Dunkin:
                        chosenType = RestaurantType.CoffeeShop;
                        break;
                    case RestaurantName.BaskinRobbins:
                        chosenType = RestaurantType.IceCreamParlor;
                        break;
                    case RestaurantName.PizzaHut:
                    case RestaurantName.Dominos:
                        chosenType = RestaurantType.PizzaPlace;
                        break;
                    default:
                        chosenType = RestaurantType.CasualDining;
                        break;
                }
            }

            return new Restaurant(chosenName, chosenType, city);
        }

    }
}
