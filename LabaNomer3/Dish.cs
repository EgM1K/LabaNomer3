using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class Dish
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Calories { get; set; }
        public RestaurantType Type { get; set; }

        public Dish(string name, string description, double price, int calories, RestaurantType type)
        {
            Name = name;
            Description = description;
            Price = price;
            Calories = calories;
            Type = type;
        }
        public static List<Dish> Dishes = new List<Dish>
        {
         new Dish("Гамбургери", "Смачний гамбургер зі свіжими овочами та соусом", 30, 350, RestaurantType.FastFood),
            new Dish("Хот-доги", "Соковитий хот-дог з гарячими ковбасками та гірчицею", 25, 280, RestaurantType.FastFood),
            new Dish("Фрі", "Хрусткі картопляні палички, смажені в глибокому жирі", 20, 220, RestaurantType.FastFood),
            new Dish("Чікен-нагетси", "Смажені курячі кусочки в хрусткій паніруванні", 35, 380, RestaurantType.FastFood),
            new Dish("Піца (швидка доставка)", "Сочна піца з різними начинками та тонким тістом", 40, 450, RestaurantType.FastFood),
            new Dish("Фастфудові салати", "Легкі салати зі свіжих овочів та заправлені соусом", 25, 180, RestaurantType.FastFood),

            new Dish("Стейки", "Смачні стейки з натурального м'яса", 100, 600, RestaurantType.CasualDining),
            new Dish("Рибні страви", "Ароматна риба з гарніром та соусом", 90, 450, RestaurantType.CasualDining),
            new Dish("Паста", "Вишукані паста з різними соусами та приправами", 80, 400, RestaurantType.CasualDining),
            new Dish("Бургери (покращеної якості)", "Смачні бургери з великою котлетою та свіжими овочами", 60, 500, RestaurantType.CasualDining),
            new Dish("Страви з гриля", "Страви, смажені на грилі з ароматними спеціями", 85, 480, RestaurantType.CasualDining),
            new Dish("Салати та закуски", "Свіжі салати та закуски для здорового перекусу", 50, 250, RestaurantType.CasualDining),

            new Dish("Кава (американо, лате, капучино, еспресо)", "Ароматна кава різних сортів з різними смаками", 40, 5, RestaurantType.CoffeeShop),
            new Dish("Чай", "Чай з різними смаками та ароматами", 30, 10, RestaurantType.CoffeeShop),
            new Dish("Печиво та кекси", "Солодкі печиво та кекси різних видів", 25, 150, RestaurantType.CoffeeShop),
            new Dish("Сендвічі та паніні", "Смачні сендвічі та паніні з різними начинками", 35, 300, RestaurantType.CoffeeShop),
            new Dish("Круасани", "Ароматні круасани з різними начинками", 30, 250, RestaurantType.CoffeeShop),
            new Dish("Мафіни та пиріжки", "Солодкі мафіни та пиріжки з різними начинками", 25, 200, RestaurantType.CoffeeShop),

            new Dish("Морозиво (різні смаки та види)", "Смачне морозиво з різними смаками та начинками", 20, 150, RestaurantType.IceCreamParlor),
            new Dish("Льодяники", "Льодяники різних смаків для освіження", 15, 120, RestaurantType.IceCreamParlor),
            new Dish("Фруктові коктейлі з морозивом", "Освіжаючі фруктові коктейлі з додаванням морозива", 25, 200, RestaurantType.IceCreamParlor),
            new Dish("Морозивні келихи та різноманітні топінги", "Морозивні келихи з різноманітними топінгами", 30, 250, RestaurantType.IceCreamParlor),

            new Dish("Піца (різні смаки та розміри)", "Смачна піца з різними начинками та розмірами", 45, 400, RestaurantType.PizzaPlace),
            new Dish("Салати", "Свіжі салати з різними овочами та заправками", 35, 180, RestaurantType.PizzaPlace),
            new Dish("Коктейлі та напої", "Освіжаючі коктейлі та напої", 40, 120, RestaurantType.PizzaPlace),
            new Dish("Снеки (часничний хліб, мідії, оливки)", "Снеки, що доповнять ваше меню", 30, 250, RestaurantType.PizzaPlace)
        };
    }
}

