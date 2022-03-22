using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse
{
    public class Client
    {
        public static List<Client> clients;

        public static Client defaultClient;
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public CartItem cart;

        public List<Order> orders;

        static Client()
        {
            clients = new List<Client>();
            defaultClient = new Client("defaultClient", "defaultClient", "defaultClient", "defaultClient");
        }

        public Client(string fullName, string phoneNumber, string email, string password)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            cart = new CartItem();
            orders = new List<Order>();
        }

        public static Client GiveMeClient(string password, string email)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Email == email && clients[i].Password == password)
                {
                    return clients[i];
                }
            }
            return clients[0];
        }

        public static string PasswordFromEmail(string email)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Email == email)
                {
                    return clients[i].Password;
                }
            }
            return "";
        }

        public static bool HasThisEmail(string email)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public static void UpdateClient(Client newClient)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (newClient.Email == clients[i].Email)
                {
                    clients[i] = newClient;
                    return;
                }
            }
        }
    }
}
