using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class DeliveryManager
    {
        public List<Courier> AvailableCouriers { get; set; }
        public DeliveryManager(List<Courier> couriers)
        {
            AvailableCouriers = couriers;
        }
        public Courier AssignCourier()
        {
            return AvailableCouriers[0];
        }
        public void TrackOrder(Order order)
        {
            Console.WriteLine($"Order status: {order.Status}");
        }
    }
}
