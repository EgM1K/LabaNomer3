using LabaNomer3;
public class Client
{
    public string Name { get; set; }
    public string DeliveryAddress { get; set; }
    public string ContactNumber { get; set; }
    public List<Order> OrderHistory { get; set; }

    public Client()
    {
        OrderHistory = new List<Order>();
        GetClientInformation();
    }

    protected virtual void GetClientInformation()
    {
        List<string> Kyivstar = new List<string> { "67", "68", "96", "97", "98" };
        List<string> Vodafone = new List<string> { "50", "66", "95", "99" };
        List<string> Lifecell = new List<string> { "63", "93", "73" };

        while (true)
        {
            try
            {
                Name = GetInput("Будь ласка, введіть ваше ім'я: ", "Ім'я повинно містити лише букви.", input => input.All(Char.IsLetter));
                DeliveryAddress = GetInput("Будь ласка, введіть вашу адресу доставки: ");
                ContactNumber = GetInput("Будь ласка, введіть ваш контактний номер(введіть рівно 9 чисел): +380", "Номер телефону повинен містити рівно 9 цифр і починатися з відповідних двох цифр оператора.", number => number.Length == 9 && (Kyivstar.Contains(number.Substring(0, 2)) || Vodafone.Contains(number.Substring(0, 2)) || Lifecell.Contains(number.Substring(0, 2))));
                ContactNumber = "+380" + ContactNumber;

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
                                Name = GetInput("Будь ласка, введіть ваше ім'я: ", "Ім'я повинно містити лише букви.", input => input.All(Char.IsLetter));
                                break;
                            case "2":
                                DeliveryAddress = GetInput("Будь ласка, введіть вашу адресу доставки: ");
                                break;
                            case "3":
                                ContactNumber = GetInput("Будь ласка, введіть ваш контактний номер(введіть рівно 9 чисел): +380", "Номер телефону повинен містити рівно 9 цифр і починатися з відповідних двох цифр оператора.", number => number.Length == 9 && (Kyivstar.Contains(number.Substring(0, 2)) || Vodafone.Contains(number.Substring(0, 2)) || Lifecell.Contains(number.Substring(0, 2))));
                                ContactNumber = "+380" + ContactNumber;
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

    private string GetInput(string prompt, string errorMessage = "", Func<string, bool> validate = null)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (validate == null || validate(input))
            {
                Console.WriteLine("Ви ввели: {0}", input);
                return input;
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        }
    }

    public virtual void LeaveReview()
    {
        Console.Write("Будь ласка, введіть ваш відгук: ");
        string reviewText = Console.ReadLine();
        Console.Write("Будь ласка, введіть вашу оцінку: ");
        int rating = Convert.ToInt32(Console.ReadLine());

        Review review = new Review(this.Name, reviewText, rating, ContactNumber);
        review.SaveReview();
    }
}
