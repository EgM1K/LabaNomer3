using LabaNomer3;
public class Client
{
    public string Name { get; set; }
    public string DeliveryAddress { get; set; }
    public string ContactNumber { get; set; }
    public List<Order> OrderHistory { get; set; }

    public Client()
    {
        List<string> Kyivstar = new List<string> { "67", "68", "96", "97", "98" };
        List<string> Vodafone = new List<string> { "50", "66", "95", "99" };
        List<string> Lifecell = new List<string> { "63", "93", "73" };

        while (true)
        {
            try
            {
                while (true)
                {
                    Console.Write("Будь ласка, введіть ваше ім'я: ");
                    string name = Console.ReadLine();
                    if (!name.All(Char.IsLetter))
                    {
                        throw new Exception("Ім'я повинно містити лише букви.");
                    }
                    Name = name;
                    Console.WriteLine("Ви ввели ім'я: {0}", Name);
                    break;
                }

                while (true)
                {
                    Console.Write("Будь ласка, введіть вашу адресу доставки: ");
                    DeliveryAddress = Console.ReadLine();
                    Console.WriteLine("Ви ввели адресу доставки: {0}", DeliveryAddress);
                    break;
                }

                while (true)
                {
                    Console.Write("Будь ласка, введіть ваш контактний номер(введіть рівно 9 чисел): +380");
                    string number = Console.ReadLine();
                    if (number.Length != 9 || !(Kyivstar.Contains(number.Substring(0, 2)) || Vodafone.Contains(number.Substring(0, 2)) || Lifecell.Contains(number.Substring(0, 2))))
                    {
                        throw new Exception("Номер телефону повинен містити рівно 9 цифр і починатися з відповідних двох цифр оператора.");
                    }
                    ContactNumber = "+380" + number;
                    Console.WriteLine("Ви ввели номер телефону: {0}", ContactNumber);
                    break;
                }

                OrderHistory = new List<Order>();

                Console.WriteLine("Все вірно? (1) так (2) ні (3) змінити деякі пункти");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        return;
                    case "2":
                        continue;
                    case "3":
                        Console.WriteLine("Що ви хочете змінити? (1) Ім'я (2) Адреса доставки (3) Номер телефону");
                        string changeOption = Console.ReadLine();
                        switch (changeOption)
                        {
                            case "1":
                                while (true)
                                {
                                    Console.Write("Будь ласка, введіть ваше ім'я: ");
                                    string name = Console.ReadLine();
                                    if (!name.All(Char.IsLetter))
                                    {
                                        throw new Exception("Ім'я повинно містити лише букви.");
                                    }
                                    Name = name;
                                    Console.WriteLine("Ви ввели ім'я: {0}", Name);
                                    return;
                                }
                                break;
                            case "2":
                                while (true)
                                {
                                    Console.Write("Будь ласка, введіть вашу адресу доставки: ");
                                    DeliveryAddress = Console.ReadLine();
                                    Console.WriteLine("Ви ввели адресу доставки: {0}", DeliveryAddress);
                                    break;
                                }
                                return;
                            case "3":
                                while (true)
                                {
                                    Console.Write("Будь ласка, введіть ваш контактний номер(введіть рівно 9 чисел): +380");
                                    string number = Console.ReadLine();
                                    if (number.Length != 9 || !(Kyivstar.Contains(number.Substring(0, 2)) || Vodafone.Contains(number.Substring(0, 2)) || Lifecell.Contains(number.Substring(0, 2))))
                                    {
                                        throw new Exception("Номер телефону повинен містити рівно 9 цифр і починатися з відповідних двох цифр оператора.");
                                    }
                                    ContactNumber = "+380" + number;
                                    Console.WriteLine("Ви ввели номер телефону: {0}", ContactNumber);
                                    return;
                                }
                                break;
                            default:
                                Console.WriteLine("Невідома опція. Будь ласка, спробуйте ще раз.");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Невідома опція. Будь ласка, спробуйте ще раз.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}. Будь ласка, спробуйте ще раз.");
            }
        }
    }
    public void LeaveReview()
    {
        Console.Write("Будь ласка, введіть ваш відгук: ");
        string reviewText = Console.ReadLine();
        Console.Write("Будь ласка, введіть вашу оцінку: ");
        int rating = Convert.ToInt32(Console.ReadLine());

        Review review = new Review(this.Name, reviewText, rating, ContactNumber);
        review.SaveReview();
    }
}

