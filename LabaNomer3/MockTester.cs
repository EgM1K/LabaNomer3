using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class MockTester
    {
        public List<Client> Clients { get; set; }
        public DeliveryManager DeliveryManager { get; set; }
        public MockTester(List<Client> clients, DeliveryManager deliveryManager)
        {
            Clients = clients;
            DeliveryManager = deliveryManager;
        }
        public void TestDeliveryService()
        {

        }
    }
}