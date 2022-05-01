using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverSubscribers
{
    public interface IPublisher
    {
        void Attach(ISubscriber observer);
        void Detach(ISubscriber observer);
        void AddSomeProducts(List<string> products) {
            this.Notify();
        }
        public void Notify();
    }
    public class Publisher : IPublisher
    {

        private List<string> products = new List<string>();

        private List<ISubscriber> subscribers = new List<ISubscriber>();

        public void Attach(ISubscriber observer)
        {
            Console.WriteLine($"Магазин: теперь {(observer as Subscriber).name} наш подписчик");
            this.subscribers.Add(observer);
        }

        public void Detach(ISubscriber observer)
        {
            this.subscribers.Remove(observer);
            Console.WriteLine($"Магазин: теперь {(observer as Subscriber).name} не наш подписчик((");
        }

        public void Notify()
        {
            Console.WriteLine("\nМагазин: уведомление подписчиков..");


            foreach (var observer in subscribers)
            {
                Thread.Sleep((observer as Subscriber).timeToNoify);
                observer.Update(this);
            }

        }

        public void AddSomeProducts(List<string> products)
        {
            this.products.AddRange(products);
            Console.WriteLine($"\nМагазин: у нас завоз товаров:");

            foreach (var product in products)
                Console.WriteLine($"На складе появился товар - {product}");

            Notify();
        }

        public List<string> GetProductsList()
        {
            return this.products;
        }
    }



    public interface ISubscriber
    {
        void Update(IPublisher subject);
    }

    public class Subscriber
    {
        public int timeToNoify = 0;
        public string name = "new subscriber";
        public List<string> boughtItems = new List<string>();
        public Subscriber(int subTime, string subName)
        {
            this.timeToNoify = subTime;
            this.name = subName;
        }
    }

    public class Subscriber1 : Subscriber, ISubscriber
    {
        public Subscriber1(int subTime, string subName) : base(subTime, subName)
        {
            this.timeToNoify = subTime;
            this.name = subName;
        }
        public void Update(IPublisher publisher)
        {
            foreach (var item in (publisher as Publisher).GetProductsList())
            {
                if (item == "Сырок Б.Ю. Александров")
                {
                    Console.WriteLine("Subscriber1: Отлично, я искал сырок!");
                    boughtItems.Add(item);
                }
            }

        }
    }

    public class Subscriber2 : Subscriber, ISubscriber
    {
        public Subscriber2(int subTime, string subName) : base(subTime, subName)
        {
            this.timeToNoify = subTime;
            this.name = subName;
        }
        public void Update(IPublisher publisher)
        {
            foreach (var item in (publisher as Publisher).GetProductsList())
            {
                if (item == "Кофе Bushido")
                {
                    Console.WriteLine("Subscriber2: Отлично, я искал Кофе Bushido!");
                    boughtItems.Add(item);
                }
            }

        }
    }
}
