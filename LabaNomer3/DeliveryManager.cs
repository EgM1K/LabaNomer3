using LabaNomer3;
using System;
using System.Diagnostics.Metrics;

public class DeliveryManager
{
    public List<Courier> AvailableCouriers { get; set; }
    public List<Dish> Menu { get; set; }
    public string DeliveryAddress { get; set; }

    public DeliveryManager()
    {
        AvailableCouriers = GenerateCouriers();
    }
    public virtual Restaurant ChooseRestaurant()
    {
        while (true)
        {
            Console.Write("Введіть місто: ");
            string city = Console.ReadLine();

            Console.WriteLine("Виберіть ресторан: \n(1) McDonalds \n(2) KFC \n(3) BurgerKing \n(4) Subway \n(5) Starbucks \n(6) PizzaHut \n(7) Dominos \n(8) Dunkin \n(9) BaskinRobbins \n(10) Custom"); ;
            int chosenNumber = Int32.Parse(Console.ReadLine());

            if (chosenNumber < 1 || chosenNumber > 10)
            {
                Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                continue;
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

            Restaurant chosenRestaurant = new Restaurant(chosenName, chosenType, city);
            chosenRestaurant.DisplayInfo();

            Console.WriteLine("Вас все задовольняє? (1) так (2) ні");
            int satisfactionResponse = Int32.Parse(Console.ReadLine());
            switch (satisfactionResponse)
            {
                case 1:
                    return chosenRestaurant;
                case 2:
                    Console.WriteLine("Давайте спробуємо знову.");
                    break;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
    public virtual Dish ChooseDish()
    {
        Console.WriteLine("Виберіть страву:");
        for (int i = 0; i < Menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Menu[i].Name}, Опис: {Menu[i].Description}, Ціна: {Menu[i].Price}, Калорії: {Menu[i].Calories}");
        }

        int chosenNumber = Int32.Parse(Console.ReadLine());

        if (chosenNumber < 1 || chosenNumber > Menu.Count)
        {
            Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
            return ChooseDish();
        }

        return Menu[chosenNumber - 1];
    }

    public virtual Order CreateOrder(Client client, Restaurant chosenRestaurant, DeliveryManager manager)
    {
        Order order = new Order(new List<Dish>(), chosenRestaurant, client);
        while (true)
        {
            order = InputOrderDetails(manager, order);
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    break;
                case "2":
                    OutputOrderDetails(order);
                    return order;
                default:
                    Console.WriteLine("Невідома опція. Будь ласка, спробуйте ще раз.");
                    break;
            }
        }
    }

    public static Order InputOrderDetails(DeliveryManager manager, Order order)
    {
        var chosenDish = manager.ChooseDish();
        manager.AddDishToOrder(order, chosenDish);
        Console.WriteLine("Вибрати ще одну страву? (1 - так, 2 - ні)");
        return order;
    }

    public static void OutputOrderDetails(Order order)
    {
        order.UpdateStatus(OrderStatus.Created);
        order.DisplayOrderDetails();
        System.Threading.Thread.Sleep(2000);
        Console.Clear();
        order.UpdateStatus(OrderStatus.InProgress);
        order.DisplayOrderDetails();
        System.Threading.Thread.Sleep(5000);
        Console.Clear();
        order.UpdateStatus(OrderStatus.Completed);
        order.DisplayOrderDetails();
    }
    public void AddDishToOrder(Order order, Dish dish)
    {
        order.Dishes.Add(dish);
        order.TotalAmount += dish.Price;
    }
    public double CalculateDeliveryTime(double distance, int speed)
    {
        return distance / speed;
    }

    public double CalculateDeliveryCost(double distance, double costPerKm)
    {
        return distance * costPerKm;
    }
    protected List<Courier> GenerateCouriers()
    {
        Random rand = new Random();
        int courierCount = rand.Next(4, 8);
        List<Courier> couriers = new List<Courier>();
        for (int i = 0; i < courierCount; i++)
        {
            string courierName = Courier.courierNames[rand.Next(Courier.courierNames.Count)];
            (string type, int speed, double costPerKm) courierTransport = Courier.transportTypes[rand.Next(Courier.transportTypes.Count)];
            double courierRating = rand.NextDouble() * 5;
            string operatorCode = Courier.operatorCodes[rand.Next(Courier.operatorCodes.Count)];
            string phoneNumber = "+38" + operatorCode + rand.Next(1000000, 9999999).ToString();
            var courier = new Courier(courierName, phoneNumber, courierRating, courierTransport);
            couriers.Add(courier);
        }
        return couriers;
    }
    public void TrackOrder(Order order)
    {
        Console.WriteLine($"Order status: {order.Status}");
    }
    public virtual Courier SelectCourier(Client client, Order order)
    {
        Courier courier = null;
        while (true)
        {
            Console.WriteLine("Виберіть кур'єра (0 для випадкового вибору):");
            for (int i = 0; i < AvailableCouriers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {AvailableCouriers[i].Name}, Транспорт: {AvailableCouriers[i].Transport.type}");
            }

            string courierChoice = Console.ReadLine();

            if (courierChoice == "0")
            {
                Random rand = new Random();
                courier = AvailableCouriers[rand.Next(AvailableCouriers.Count)];
            }
            else if (int.TryParse(courierChoice, out int index) && index > 0 && index <= AvailableCouriers.Count)
            {
                courier = AvailableCouriers[index - 1];
            }
            else
            {
                Console.WriteLine("Невідома опція. Будь ласка, введіть номер кур'єра.");
                continue;
            }
            break;
        }
        return courier;
    }

    public virtual void EndInfo(Client client, Order order, Courier courier)
    {
        Random rand = new Random();
        double distance = rand.Next(3, 21);
        double deliveryTime = CalculateDeliveryTime(distance, courier.Transport.speed);
        double deliveryCost = CalculateDeliveryCost(distance, 6);

        Console.WriteLine($"Кур'єр {courier.Name} доставив ваше замовлення на адресу {client.DeliveryAddress} за {deliveryTime * 60} хвилин на дистанцію {distance} кілометрів.");
        Console.WriteLine($"З вас {order.TotalAmount + deliveryCost} грн (включаючи вартість доставки за кілометр - {courier.Transport.costPerKm} грн).");
        Console.Write("Введіть номер картки для оплати: ");
        string cardNumber = Console.ReadLine();

        if (rand.NextDouble() <= 0.2)
        {
            order.UpdateStatus(OrderStatus.NotDelivered);
            Console.WriteLine("Оплата не пройшла. Ого бідний!! - Мегеджер Служби доставки");
        }
        else
        {
            Console.WriteLine("Оплата пройшла успішно, Смачного!! - Менеджер Служби доставки.");
            order.UpdateStatus(OrderStatus.Delivered);
        }
        Console.WriteLine($"Статус замовлення: {order.Status}");

    System.Threading.Thread.Sleep(5000);
    }

}



