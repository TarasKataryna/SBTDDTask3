using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    /// <summary>
    /// Save all the data about client and his/her order
    /// </summary>
    public class Order
    {
        public List<Sushi> sushis;
        public double TotalPrice { get; protected set; }
        public string ClientFullName { get; protected set; }
        public bool isSubmitted = false;
        public string Path { get; set; }
        public bool Exists { get; set; } = false;
        public int Counter { get; set; }
        public Order()
        {
            sushis = new List<Sushi>();
        }
        public Order(string name)
        {
            sushis = new List<Sushi>();
            ClientFullName = name;
            string path = Directory.GetCurrentDirectory()+@"\sushi.txt";
            Path = path;
            Counter = 1;
        }

        /// <summary>
        /// Adding sushi to order 
        /// </summary>
        /// <param name="sushi"></param>
        public void addToOrder(Sushi sushi)
        {
            sushis.Add(sushi);
            TotalPrice += sushi.Price;
        }

        /// <summary>
        /// Deleting sushi from order
        /// </summary>
        /// <param name="sushi"></param>
        public void deleteFromOrder(Sushi sushi)
        {
            int index = sushis.FindIndex(v => v.Name == sushi.Name);
            if (index != -1)
            {
                sushis.RemoveAt(index);
                TotalPrice -= sushi.Price;
            }
        }

        /// <summary>
        /// Deleting all sushi from order
        /// </summary>
        /// <param name="sushi"></param>
        public void deleteAllFromOrder(Sushi sushi)
        {
            int c = sushis.Count(s => s.Name == sushi.Name);
            TotalPrice -= c * sushi.Price;
            sushis.RemoveAll(v => v.Name == sushi.Name);
        }

        /// <summary>
        /// Submit order and write this order to db
        /// </summary>
        public void submitOrder()
        {
            if (sushis.Count == 0)
                return;
            string str = string.Empty;
            if (File.Exists(Path))
            {
                FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.ReadWrite);
                using (StreamReader srr = new StreamReader(fs))
                {
                    str = srr.ReadToEnd();
                    fs.Position = 0;
                    Counter = Int32.Parse(srr.ReadLine().Split(' ')[1]);
                    Counter++;
                    Exists = true;
                }                
                File.Delete(Path);
            }            
            using (StreamWriter streamWriter = new StreamWriter(Path, true))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Order " + Counter + " " + ClientFullName);
                foreach (var item in sushis)
                {
                    stringBuilder.AppendLine(item.Name + " " + item.Price);
                }
                stringBuilder.AppendLine("Total price: " + TotalPrice);
                stringBuilder.AppendLine();
                isSubmitted = true;
                if (Exists)
                    streamWriter.Write(stringBuilder + Environment.NewLine + str);
                else
                    streamWriter.Write(stringBuilder.ToString());
                sushis.Clear();
            }
        }

        /// <summary>
        /// Finding orders in db by client name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="streamReader"></param>
        /// <returns></returns>
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
