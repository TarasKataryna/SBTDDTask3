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
namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Order newO = new Order("q");
            newO.addToOrder(new Nigiri());
            newO.addToOrder(new Maki());
            newO.submitOrder();

            Order newOo = new Order("w");
            newOo.addToOrder(new Sashimi());
            newOo.addToOrder(new Uramaki());
            newOo.submitOrder();

            Order kk = new Order();
            StreamReader streamReader = new StreamReader(@"C:\Users\tarik\source\repos\Task3\OrderLib\bin\Debug\Orders.txt");
            var t = kk.findOrderByName("q", streamReader);
            streamReader.Close();
            t.submitOrder();


        }
    }
}
