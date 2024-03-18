using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class Client
    {
        public string Name { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactNumber { get; set; }
        public List<Order> OrderHistory { get; set; }

        public Client()
        {
            Console.Write("Будь ласка, введіть ваше ім'я: ");
            Name = Console.ReadLine();

            Console.Write("Будь ласка, введіть вашу адресу доставки: ");
            DeliveryAddress = Console.ReadLine();

            Console.Write("Будь ласка, введіть ваш контактний номер: +380");
            ContactNumber = "+380" + Console.ReadLine();

            OrderHistory = new List<Order>();
        }
    }
}
