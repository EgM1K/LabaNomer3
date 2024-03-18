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
                        Console.Clear();
                        Random rand = new Random();
                        int courierCount = rand.Next(4, 8);
                        List<Courier> couriers = new List<Courier>();
                        for (int i = 0; i < courierCount; i++)
                        {
                            string courierName = Courier.courierNames[rand.Next(Courier.courierNames.Count)];
                            (string type, int speed) courierTransport = Courier.transportTypes[rand.Next(Courier.transportTypes.Count)];
                            double courierRating = rand.NextDouble() * 5;
                            string operatorCode = Courier.operatorCodes[rand.Next(Courier.operatorCodes.Count)];
                            string phoneNumber = "+38" + operatorCode + rand.Next(1000000, 9999999).ToString();
                            var courier = new Courier(courierName, phoneNumber, courierRating, courierTransport);
                            couriers.Add(courier);
                        }

                        while (true)
                        {
                            Console.WriteLine("Виберіть кур'єра:");
                            for (int i = 0; i < couriers.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {couriers[i].Name}, Транспорт: {couriers[i].Transport.type}");
                            }

                            string courierChoice = Console.ReadLine();

                            switch (courierChoice)
                            {
                                case "1":
                                case "2":
                                case "3":
                                    int index = int.Parse(courierChoice) - 1;
                                    couriers[index].ShowCourierDetails();
                                    Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
                                    Console.ReadKey();
                                    return;
                                default:
                                    Console.WriteLine("Невідома опція. Будь ласка, введіть номер кур'єра.");
                                    break;
                            }
                        }
                }

            }
        }
    }
}

