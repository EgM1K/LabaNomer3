using LabaNomer3;
internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Вітаємо це служба доставки 'Смачна Подорож'");

        Console.WriteLine("Виберіть режим: (1) Стандартний ввід/вивід (2) Мок-тестери");
        string mode = Console.ReadLine();

        Client client;
        DeliveryManager deliveryManager;
        Restaurant chosenRestaurant;
        Courier courier;

        switch (mode)
        {
            case "1":
                client = new Client();
                deliveryManager = new DeliveryManager();
                chosenRestaurant = deliveryManager.ChooseRestaurant();
                chosenRestaurant.DisplayInfo();
                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();

                deliveryManager.Menu = chosenRestaurant.Menu;
                var order = deliveryManager.CreateOrder(client, chosenRestaurant, deliveryManager);
                order = DeliveryManager.InputOrderDetails(deliveryManager, order);
                DeliveryManager.OutputOrderDetails(order);
                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();
                courier = deliveryManager.SelectCourier(client, order);
                courier.ShowCourierDetails();
                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();

                deliveryManager.EndInfo(client, order, courier);
                client.LeaveReview();
                Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
                Console.ReadKey();
                break;
            case "2":
                client = new MockTesterClient();
                deliveryManager = new MockTesterDelivery();
                chosenRestaurant = deliveryManager.ChooseRestaurant();
                chosenRestaurant.DisplayInfo();
                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();
                deliveryManager.Menu = chosenRestaurant.Menu;
                order = deliveryManager.CreateOrder(client, chosenRestaurant, deliveryManager);
                DeliveryManager.OutputOrderDetails(order);
                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();
                courier = deliveryManager.SelectCourier(client, null);
                courier.ShowCourierDetails();
                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();
                deliveryManager.EndInfo(client, order, courier);
                Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Невідома опція. Будь ласка, спробуйте ще раз.");
                return;
        }
    }
}
