// <copyright file="UnitTest1.cs" company="Sprocket Enterprises">
//     Copyright (c) SBTDD. All rights reserved.
// </copyright>

namespace SushiTestProj
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OrderLib;
    [TestClass]

    /// <summary>
    /// Testing order class
    /// </summary>
    public class UnitTest1
    {
        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestAddOrderMethod1()
        {
            Order order = new Order();
            order.addToOrder(new Nigiri());
            Assert.AreEqual(1, order.sushis.Count);
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestAddOrderMethod2()
        {
            Order order = new Order();
            order.addToOrder(new Nigiri());
            Assert.AreEqual(typeof(Nigiri), order.sushis[0].GetType());
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestDeleteOrderMethod1()
        {
            Order order = new Order();
            Nigiri nigiri = new Nigiri();
            order.addToOrder(nigiri);
            order.deleteFromOrder(nigiri);
            Assert.AreEqual(0, order.sushis.Count);
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestDeleteOrderMethod2()
        {
            Order order = new Order();
            Nigiri nigiri = new Nigiri();
            Nigiri nigiri2 = new Nigiri();
            order.addToOrder(nigiri);
            order.addToOrder(nigiri2);

            order.addToOrder(new Uramaki());

            order.deleteAllFromOrder(nigiri);
            Assert.AreEqual(typeof(Uramaki), order.sushis[0].GetType());
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestDeleteOrderMethod3()
        {
            Order order = new Order();
            Nigiri nigiri = new Nigiri();
            Nigiri nigiri2 = new Nigiri();
            order.addToOrder(nigiri);
            order.addToOrder(nigiri2);

            order.addToOrder(new Uramaki());

            order.deleteAllFromOrder(nigiri);
            Assert.AreEqual(1, order.sushis.Count);
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestSubmitOrder1()
        { 
            Order order = new Order("Edik");
            if (File.Exists(order.Path))
            {
                File.Delete(order.Path);
            }

            order.addToOrder(new Uramaki());
            order.submitOrder();
            StreamReader sr = File.OpenText(order.Path);
            string[] tmp = sr.ReadLine().Split(' ');
            sr.Close();
            Assert.AreEqual(1, int.Parse(tmp[1]));
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestSubmitOrder2()
        {
            Order order = new Order("Edik");
            if (File.Exists(order.Path))
            {
                File.Delete(order.Path);
            }

            order.addToOrder(new Uramaki());
            order.submitOrder();
            StreamReader sr = File.OpenText(order.Path);
            string[] tmp = sr.ReadLine().Split(' ');
            sr.Close();
            Assert.AreEqual("Edik", tmp[2]);
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestSubmitOrder3()
        {
            Order order = new Order("Edik");
            if (File.Exists(order.Path))
            {
                File.Delete(order.Path);
            }

            order.addToOrder(new Uramaki());
            order.submitOrder();
            StreamReader sr = File.OpenText(order.Path);
            string[] tmp = sr.ReadLine().Split(' ');
            tmp = sr.ReadLine().Split(' ');
            sr.Close();
            Assert.AreEqual("Uramaki", tmp[0]);
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestSubmitOrder4()
        {
            Order order = new Order("Edik");
            if (File.Exists(order.Path))
            {
                File.Delete(order.Path);
            }

            order.addToOrder(new Uramaki());
            order.submitOrder();
            StreamReader sr = File.OpenText(order.Path);
            string[] tmp = sr.ReadLine().Split(' ');
            tmp = sr.ReadLine().Split(' ');
            tmp = sr.ReadLine().Split(' ');
            sr.Close();
            Assert.AreEqual(220.0, double.Parse(tmp[2]));
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestSubmitOrder5()
        {
            Order order = new Order("Edik");
            if (File.Exists(order.Path))
            {
                File.Delete(order.Path);
            }

            order.addToOrder(new Uramaki());
            order.addToOrder(new Uramaki());
            order.submitOrder();
            StreamReader sr = File.OpenText(order.Path);
            string[] tmp = sr.ReadLine().Split(' ');
            tmp = sr.ReadLine().Split(' ');
            tmp = sr.ReadLine().Split(' ');
            tmp = sr.ReadLine().Split(' ');
            sr.Close();
            Assert.AreEqual(440.0, double.Parse(tmp[2]));
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestSubmitOrder6()
        {
            Order order = new Order("Edik");
            order.addToOrder(new Uramaki());
            order.addToOrder(new Uramaki());
            order.submitOrder();
            Assert.AreEqual(0, order.sushis.Count);
        }

        [TestMethod]

        /// <summary>
        /// blah blah blah
        /// </summary>
        public void TestSubmitOrder7()
        {
            Order order = new Order("Edik");
            if (File.Exists(order.Path))
            {
                File.Delete(order.Path);
            }

            order.addToOrder(new Uramaki());
            order.addToOrder(new Uramaki());
            order.submitOrder();
            order = new Order("Zdorov");
            order.addToOrder(new Rolls());
            order.addToOrder(new Nigiri());
            order.submitOrder();
            StreamReader sr = File.OpenText(order.Path);
            string[] tmp = sr.ReadLine().Split(' ');
            sr.Close();
            Assert.AreEqual(2, int.Parse(tmp[1]));
        }
    }
}
