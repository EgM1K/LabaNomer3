using LabaNomer3;
internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Вітаємо в системі вибору ресторану!");

        Console.Write("Будь ласка, введіть ваше ім'я: ");
        string name = Console.ReadLine();

        Console.Write("Будь ласка, введіть вашу адресу доставки: ");
        string deliveryAddress = Console.ReadLine();

        Console.Write("Будь ласка, введіть ваш контактний номер: +380");
        string contactNumber = Console.ReadLine();

        var client = new Client(name, deliveryAddress, "+380" + contactNumber);

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