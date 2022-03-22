using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WareHouse
{
    public class Order
    {
        public static List<Order> allOrders;
        public CartItem Cart { get; private set; }
        public double FullPrice { get; private set; }
        public long Id { get; private set; }
        public DateTime Date { get; private set; }
        public Client Client { get; private set; }

        public enum Status { обработан, оплачен, отгружен, исполнен}

        public Status CurStatus { get; set; }

        static Order()
        {
            allOrders = new List<Order>();
        }


        public Order(CartItem cart, double fullPrice, Client client)
        {
            Cart = cart;
            FullPrice = fullPrice;
            Id = allOrders.Count;
            Date = DateTime.Now;
            Client = client;
            CurStatus = Status.обработан;           
        }

    }
}
