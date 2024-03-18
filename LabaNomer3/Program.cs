using LabaNomer3;
internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Вітаємо це служба доставки 'Смачна Подорож'");
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
        client.LeaveReview();
        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}