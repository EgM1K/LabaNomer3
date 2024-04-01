using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class MockTesterClient : Client
    {
        public MockTesterClient()
        {
            OrderHistory = new List<Order>();
        }

        protected override void GetClientInformation()
        {
            Name = "Тестове Ім'я";
            DeliveryAddress = "Тестова Адреса";
            ContactNumber = "+380501234567";

            Console.WriteLine($"Введено ім'я: {Name}");
            Console.WriteLine($"Введено адресу доставки: {DeliveryAddress}");
            Console.WriteLine($"Введено контактний номер: {ContactNumber}");
        }

        public override void LeaveReview()
        {
            string reviewText = "Тестовий відгук";
            int rating = 5;

            Review review = new Review(this.Name, reviewText, rating, ContactNumber);
            review.SaveReview();
        }
    }
}
