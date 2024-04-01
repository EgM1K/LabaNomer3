using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class MockTesterDelivery : DeliveryManager
    {
        public MockTesterDelivery()
        {
            AvailableCouriers = GenerateCouriers();
        }

        public override Restaurant ChooseRestaurant()
        {
            string city = "Київ";
            RestaurantName chosenName = RestaurantName.McDonalds;
            RestaurantType chosenType = RestaurantType.FastFood;

            return new Restaurant(chosenName, chosenType, city);
        }

        public override Dish ChooseDish()
        {
            return Menu[0];
        }
        public override Order CreateOrder(Client client, Restaurant chosenRestaurant, DeliveryManager manager)
        {
            Order order = new Order(new List<Dish> { Menu[0] }, chosenRestaurant, client);
            return order;
        }
        public override Courier SelectCourier(Client client, Order order)
        {
            return AvailableCouriers[0];
        }

        public override void EndInfo(Client client, Order order, Courier courier)
        {
            double distance = 10;
            double deliveryTime = CalculateDeliveryTime(distance, courier.Transport.speed);
            double deliveryCost = CalculateDeliveryCost(distance, 6);

            Console.WriteLine($"Кур'єр {courier.Name} доставив ваше замовлення на адресу {client.DeliveryAddress} за {deliveryTime * 60} хвилин на дистанцію {distance} кілометрів.");
            Console.WriteLine($"З вас {order.TotalAmount + deliveryCost} грн (включаючи вартість доставки за кілометр - {courier.Transport.costPerKm} грн).");
            Console.WriteLine("Введіть номер картки для оплати: 1234567890");

            order.UpdateStatus(OrderStatus.Delivered);
            Console.WriteLine($"Статус замовлення: {order.Status}");
        }
    }
}