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
            //Order newO = new Order("q");
            //newO.addToOrder(new Nigiri());
            //newO.addToOrder(new Maki());
            //newO.submitOrder();

            //Order newOo = new Order("w");
            //newOo.addToOrder(new Sashimi());
            //newOo.addToOrder(new Uramaki());
            //newOo.submitOrder();

            //Order kk = new Order();
            //StreamReader streamReader = new StreamReader(@"C:\Task3\SBTDDTask3\OrderLib\Orders.txt");
            //var t = kk.findOrderByName("q", streamReader);
            //streamReader.Close();
            //t.submitOrder();

            ////inserting data griedview with all catalog of availbaile sushis
            //List<Sushi> allSushis = new List<Sushi> { new Maki(), new Nigiri(), new Sashimi(), new Uramaki(), new Rolls(), new Cheaps() };
            //foreach (Sushi s in allSushis)
            //{
            //    SushiDataGrid.Items.Add(s);
            //}

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

        //realization of adding to order list selected item
        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //realization of commiting order (save to txt file)
        private void commitOrderClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
