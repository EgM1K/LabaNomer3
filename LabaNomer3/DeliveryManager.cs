using LabaNomer3;

public class DeliveryManager
{
    public List<Courier> AvailableCouriers { get; set; }

    public DeliveryManager()
    {
        AvailableCouriers = GenerateCouriers();
    }
    private List<Courier> GenerateCouriers()
    {
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
        return couriers;
    }

    public void TrackOrder(Order order)
    {
        Console.WriteLine($"Order status: {order.Status}");
    }
    public Courier SelectCourier()
    {
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
                return AvailableCouriers[rand.Next(AvailableCouriers.Count)];
            }
            else if (int.TryParse(courierChoice, out int index) && index > 0 && index <= AvailableCouriers.Count)
            {
                return AvailableCouriers[index - 1];
            }
            else
            {
                Console.WriteLine("Невідома опція. Будь ласка, введіть номер кур'єра.");
            }
        }
    }
}
