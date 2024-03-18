using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class Courier
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public double Raiting { get; set; }
        public (string type, int speed) Transport { get; set; }

        public static List<string> courierNames = new List<string>
        {
            "Олександр", "Іван", "Петро", "Марія", "Ольга",
            "Анна", "Віктор", "Сергій", "Дмитро", "Василь",
            "Наталія", "Тетяна", "Євген", "Катерина", "Юрій",
            "Андрій", "Оксана", "Тарас", "Людмила", "Михайло"
        };

        public static List<(string type, int speed)> transportTypes = new List<(string type, int speed)>
        {
            ("Автомобіль", 60),
            ("Велосипед", 20),
            ("Мотоцикл", 80),
            ("Електросамокат", 25),
            ("Метро", 40),
            ("Пішки", 5)
        };

        public static List<string> operatorCodes = new List<string>
        {
            "067", "068", "096", "097", "098", // Kyivstar
            "050", "066", "095", "099", // Vodafone
            "063", "093", "073" // Lifecell
        };

        public Courier(string name, string contactInfo, double raiting, (string type, int speed) transport)
        {
            Name = name;
            ContactInfo = contactInfo;
            Raiting = raiting;
            Transport = transport;
        }

        public void ShowCourierDetails()
        {
            Console.WriteLine($"Ім'я: {Name}, Контактна інформація: {ContactInfo}, Рейтинг: {Raiting}, Тип транспорту: {Transport.type}, Швидкість: {Transport.speed} км/год");
        }
    }
}
