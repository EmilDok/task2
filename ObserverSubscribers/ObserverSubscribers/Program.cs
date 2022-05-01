using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverSubscribers
{
   

    class Program
    {
        static void Main(string[] args)
        {
            // Клиентский код.
            var Publisher = new Publisher();
            var client1 = new Subscriber1(3000, "Никита");
            Publisher.Attach(client1);

            var client2 = new Subscriber2(1700, "Андрей");
            Publisher.Attach(client2);

            List<string> newProducts = new List<string>();

            newProducts.Add("Кофе Bushido");

            Publisher.AddSomeProducts(newProducts);

            newProducts.Add("Сырок Б.Ю. Александров");
            Publisher.AddSomeProducts(newProducts);
        }
    }
}
