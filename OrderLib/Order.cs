namespace OrderLib
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Save all the data about client and his/her order
    /// </summary>
    public class Order
    {
        public List<Sushi> sushis;

        public bool isSubmitted = false;

        public Order()
        {
            sushis = new List<Sushi>();
        }

        public Order(string name)
        {
            sushis = new List<Sushi>();
            ClientFullName = name;
            string path = Directory.GetCurrentDirectory() + @"\sushi.txt";
            Path = path;
            Counter = 1;
        }

        public double TotalPrice { get; protected set; }

        public string ClientFullName { get; protected set; }

        public bool Exists { get; set; } = false;

        public int Counter { get; set; }

        private string Path { get; set; }

        /// <summary>
        /// Adding sushi to order 
        /// </summary>
        /// <param name="sushi">Sushi that you want add to order</param>
        public void addToOrder(Sushi sushi)
        {
            this.sushis.Add(sushi);
            this.TotalPrice += sushi.Price;
        }

        /// <summary>
        /// Deleting sushi from order
        /// </summary>
        /// <param name="sushi">Sushi that you want delete from order</param>
        public void deleteFromOrder(Sushi sushi)
        {
            int index = this.sushis.FindIndex(v => v.Name == sushi.Name);
            if (index != -1)
            {
                this.sushis.RemoveAt(index);
                this.TotalPrice -= sushi.Price;
            }
        }

        /// <summary>
        /// Deleting all sushi from order
        /// </summary>
        /// <param name="sushi">Delete all shushi</param>
        public void deleteAllFromOrder(Sushi sushi)
        {
            int c = this.sushis.Count(s => s.Name == sushi.Name);
            this.TotalPrice -= c * sushi.Price;
            this.sushis.RemoveAll(v => v.Name == sushi.Name);
        }

        /// <summary>
        /// Submit order and write this order to db
        /// </summary>
        public void submitOrder()
        {
            string str = string.Empty;
            if (File.Exists(this.Path))
            {
                FileStream fs = new FileStream(this.Path, FileMode.Open, FileAccess.ReadWrite);
                using (StreamReader srr = new StreamReader(fs))
                {
                    str = srr.ReadToEnd();
                    fs.Position = 0;
                    this.Counter = Int32.Parse(srr.ReadLine().Split(' ')[1]);
                    this.Counter++;
                    this.Exists = true;
                }

                File.Delete(this.Path);
            }

            using (StreamWriter streamWriter = new StreamWriter(this.Path, true))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Order " + this.Counter + " " + this.ClientFullName);
                foreach (var item in this.sushis)
                {
                    stringBuilder.AppendLine(item.Name + " " + item.Price);
                }

                stringBuilder.AppendLine("Total price: " + this.TotalPrice);
                stringBuilder.AppendLine();
                this.isSubmitted = true;
                if (this.Exists)
                {
                    streamWriter.Write(stringBuilder + Environment.NewLine + str);
                }
                else
                {
                    streamWriter.Write(stringBuilder.ToString());
                }

                    this.sushis.Clear();
            }
        }

        /// <summary>
        /// Finding orders in db by client name
        /// </summary>
        /// <param name="name">Name of client</param>
        /// <param name="streamReader">Stream to read from file</param>
        /// <returns>Return the founded order</returns>
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
