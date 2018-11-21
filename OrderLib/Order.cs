using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    public class Order
    {
        public List<Sushi> sushis;
        public double TotalPrice { get; protected set; }
        public string ClientFullName { get; protected set; }

        public Order()
        {
            sushis = new List<Sushi>();
        }
        public Order(string name)
        {
            sushis = new List<Sushi>();
            ClientFullName = name;
        }

        public void addToOrder(Sushi sushi)
        {
            sushis.Add(sushi);
            TotalPrice += sushi.Price;
        }

        public void deleteFromOrder(Sushi sushi)
        {
            int index = sushis.FindIndex(v => v.Name == sushi.Name);
            if (index != -1)
            {
                sushis.RemoveAt(index);
                TotalPrice -= sushi.Price;
            }
        }

        public void deleteAllFromOrder(Sushi sushi)
        {
            int c = sushis.Count(s => s.Name == sushi.Name);
            TotalPrice -= c * sushi.Price;
            sushis.RemoveAll(v => v.Name == sushi.Name);
        }

        public void submitOrder()
        {

            StreamWriter streamWriter = new StreamWriter(@"\\Mac\Home\Documents\gitPlatform\SBTDDTask3\OrderLib\bin\Orders.txt", true);
            streamWriter.WriteLine("Order " + OrderN.getOrderNum() + " " + ClientFullName);
            foreach (var item in sushis)
                streamWriter.WriteLine(item.Name + " " + item.Price);
            streamWriter.WriteLine("Total price: " + TotalPrice);
            streamWriter.WriteLine();
            streamWriter.Close();
        }

        public Order findOrderByName(string name, StreamReader streamReader)
        {
            Order order = new Order();
            string str;
            bool isFind = false;
            bool isEnd = false;
            while ((str = streamReader.ReadLine()) != null && !isFind)
            {
                string[] arr = str.Split();
                if (arr[0] == "Order")
                {
                    order.ClientFullName = arr[2];
                    isFind = true;
                }
            }
            if (isFind)
            {
                string[] arr;

                while (!isEnd)
                {
                    arr = str.Split();
                    switch (arr[0])
                    {
                        case "Nigiri":
                            order.addToOrder(new Nigiri());
                            break;
                        case "Maki":
                            order.addToOrder(new Maki());
                            break;
                        case "Uramaki":
                            order.addToOrder(new Uramaki());
                            break;
                        case "Sashimi":
                            order.addToOrder(new Sashimi());
                            break;
                        case "Cheaps":
                            order.addToOrder(new Cheaps());
                            break;
                        case "Rolls":
                            order.addToOrder(new Rolls());
                            break;
                        case "Total":
                            isEnd = true;
                            break;
                    }
                    str = streamReader.ReadLine();
                }

            }
            return order;
        }
    }
}
