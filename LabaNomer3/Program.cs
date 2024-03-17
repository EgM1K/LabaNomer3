namespace LabaNomer3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вітаємо в системі вибору ресторану!");
            var chosenRestaurant = Restaurant.ChooseRestaurant();
            chosenRestaurant.DisplayInfo();

            Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
            Console.ReadKey();

            Console.Clear();

            chosenRestaurant.DisplayMenu();

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
