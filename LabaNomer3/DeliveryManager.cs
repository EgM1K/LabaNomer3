using LabaNomer3;
using System.Diagnostics.Metrics;

public class DeliveryManager
{
    public List<Courier> AvailableCouriers { get; set; }

    public DeliveryManager()
    {
        AvailableCouriers = GenerateCouriers();
    }
    public double CalculateDeliveryTime(double distance, int speed)
    {
        return distance / speed;
    }

    public double CalculateDeliveryCost(double distance, double costPerKm)
    {
        return distance * costPerKm;
    }
    private List<Courier> GenerateCouriers()
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
    public Courier SelectCourier(Client client, Order order)
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

    public void EndInfo(Client client, Order order, Courier courier)
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
            Console.WriteLine("Оплата не пройшла. Пішов нахуй ніщєброд єбаний, я твою маму єбав - Менеджер Служби доставки.");
        }
        else
        {
            Console.WriteLine("Оплата пройшла успішно, Смачного!! - Менеджер Служби доставки.");
        }

        System.Threading.Thread.Sleep(5000);
    }

}



