using LabaNomer3;
internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Вітаємо це служба доставки сперми в рот вашої мами");
        var client = new Client();
        var chosenRestaurant = Restaurant.ChooseRestaurant();
        chosenRestaurant.DisplayInfo();
        Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
        Console.ReadKey();
        Console.Clear();
        chosenRestaurant.DisplayMenu();
        var order = Order.CreateOrder(client, chosenRestaurant);
        Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
        Console.ReadKey();
        Console.Clear();
        var deliveryManager = new DeliveryManager();
        var courier = deliveryManager.SelectCourier(client, order);
        courier.ShowCourierDetails();

        Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
        Console.ReadKey();
        Console.Clear();

        deliveryManager.EndInfo(client, order, courier);

        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}