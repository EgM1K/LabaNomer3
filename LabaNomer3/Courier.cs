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
        public string TransportType { get; set; }
        public Courier(string name, string contactInfo, double raiting, string transportType) 
        { 
            Name = name;
            ContactInfo = contactInfo;
            Raiting = raiting;
            TransportType = transportType;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Ім'я: {Name}, Контактна інформація: {ContactInfo}, Рейтинг: {Raiting}, Тип транспорту: {TransportType}");
        }
    }
}
