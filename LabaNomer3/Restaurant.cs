using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public double Raiting { get; set; }
        public List<Dish> Dishes { get; set; }
        public Restaurant(string name, string address, string type, double raiting, List<Dish> dishes) 
        {
            Name = name;
            Address = address;
            Type = type;
            Raiting = raiting;
            Dishes = dishes;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Ім'я: {Name}, Адрес: {Address}, Тип: {Type}, Рейтинг: {Raiting}");
        }
    }
}
