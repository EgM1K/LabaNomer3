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

        public Client(string name, string deliveryAddress, string contactNumber)
        {
            Name = name;
            DeliveryAddress = deliveryAddress;
            ContactNumber = contactNumber;
            OrderHistory = new List<Order>();
        }
    }
}
