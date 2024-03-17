namespace LabaNomer3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вітаємо в системі вибору ресторану!");
            Restaurant.ChooseRestaurant().DisplayInfo();
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
