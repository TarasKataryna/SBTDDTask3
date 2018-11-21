using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrderLib;
using System.Data;
using System.IO;
using Task3;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Order order;
        public MainWindow()
        {
            InitializeComponent();
            ////Order newO = new Order("q");
            ////newO.addToOrder(new Nigiri());
            ////newO.addToOrder(new Maki());
            ////newO.submitOrder();

            ////Order newOo = new Order("w");
            ////newOo.addToOrder(new Sashimi());
            ////newOo.addToOrder(new Uramaki());
            ////newOo.submitOrder();

            ////Order kk = new Order();
            ////StreamReader streamReader = new StreamReader(@"C:\Task3\SBTDDTask3\OrderLib\Orders.txt");
            ////var t = kk.findOrderByName("q", streamReader);
            ////streamReader.Close();
            ////t.submitOrder();

            //////inserting data griedview with all catalog of availbaile sushis
            ////List<Sushi> allSushis = new List<Sushi> { new Maki(), new Nigiri(), new Sashimi(), new Uramaki(), new Rolls(), new Cheaps() };
            ////foreach (Sushi s in allSushis)
            ////{
            ////    SushiDataGrid.Items.Add(s);
            ////}

        }

        /// <summary>
        /// MainWindow with object from LoginWindow
        /// </summary>
        /// <param name="o"></param>
        public MainWindow(Order o)
        {
            InitializeComponent();
            order = o;

            List<Sushi> allSushis = new List<Sushi> { new Maki(), new Nigiri(), new Sashimi(), new Uramaki(), new Rolls(), new Cheaps() };
            foreach (Sushi s in allSushis)
            {
                SushiDataGrid.Items.Add(s);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        ////realization of adding to order list selected item
        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String ProductName = (SushiDataGrid.SelectedItem as Sushi).Name; ;
                switch (ProductName)
                {
                    case "Nigiri":
                        order.addToOrder(new Nigiri());
                        SushiOrder.Items.Add(order.sushis[order.sushis.Count - 1]);
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Maki":
                        order.addToOrder(new Maki());
                        SushiOrder.Items.Add(order.sushis[order.sushis.Count - 1]);
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Uramaki":
                        order.addToOrder(new Uramaki());
                        SushiOrder.Items.Add(order.sushis[order.sushis.Count - 1]);
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Sashimi":
                        order.addToOrder(new Sashimi());
                        SushiOrder.Items.Add(order.sushis[order.sushis.Count - 1]);
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Cheaps":
                        order.addToOrder(new Cheaps());
                        SushiOrder.Items.Add(order.sushis[order.sushis.Count - 1]);
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Rolls":
                        order.addToOrder(new Rolls());
                        SushiOrder.Items.Add(order.sushis[order.sushis.Count - 1]);
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DeleteFromOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String ProductName = (SushiOrder.SelectedItem as Sushi).Name; ;
                switch (ProductName)
                {
                    case "Nigiri":
                        order.deleteFromOrder(new Nigiri());
                        SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Maki":
                        order.deleteFromOrder(new Maki());
                        SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Uramaki":
                        order.deleteFromOrder(new Uramaki());
                        SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Sashimi":
                        order.deleteFromOrder(new Sashimi());
                        SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Cheaps":
                        order.deleteFromOrder(new Cheaps());
                        SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                    case "Rolls":
                        order.deleteFromOrder(new Rolls());
                        SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        textBox.Text = order.TotalPrice.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    
        ////realization of commiting order (save to txt file)
        private void commitOrderClick(object sender, RoutedEventArgs e)
        {
            order.submitOrder();
            textBox.Text = 0.ToString();
            SushiOrder.Items.Clear();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            if (order.isSubmitted)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            else
            {
                string messageBoxText = "Order was not submitted, are you sure you want to log out?";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;

                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                        this.Close();
                        break;
                    case MessageBoxResult.No:
                        break;
                }

            }
        }

       
    }
}
