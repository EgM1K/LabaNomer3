namespace LabaNomer3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вітаємо в системі вибору ресторану!");

            Console.WriteLine("Будь ласка, введіть ваше ім'я:");
            string name = Console.ReadLine();

            Console.WriteLine("Будь ласка, введіть вашу адресу доставки:");
            string deliveryAddress = Console.ReadLine();

            Console.WriteLine("Будь ласка, введіть ваш контактний номер:");
            string contactNumber = Console.ReadLine();

            var client = new Client(name, deliveryAddress, contactNumber);

            var chosenRestaurant = Restaurant.ChooseRestaurant();
            chosenRestaurant.DisplayInfo();

            Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
            Console.ReadKey();

            Console.Clear();

            chosenRestaurant.DisplayMenu();

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
                        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Невідома опція. Будь ласка, введіть 1 для 'так' або 2 для 'ні'.");
                        break;
                }
            }

        }
    }
}

