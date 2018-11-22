namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using OrderLib;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Order order;

        public MainWindow()
        {
            this.InitializeComponent();
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

        public MainWindow(Order o)
        {
            this.InitializeComponent();
            this.order = o;

            List<Sushi> allSushis = new List<Sushi> { new Maki(), new Nigiri(), new Sashimi(), new Uramaki(), new Rolls(), new Cheaps() };
            foreach (Sushi s in allSushis)
            {
                this.SushiDataGrid.Items.Add(s);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Realization of adding to order list selected item
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String ProductName = (SushiDataGrid.SelectedItem as Sushi).Name; ;
                switch (ProductName)
                {
                    case "Nigiri":
                        this.order.addToOrder(new Nigiri());
                        this.SushiOrder.Items.Add(this.order.sushis[this.order.sushis.Count - 1]);
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Maki":
                        this.order.addToOrder(new Maki());
                        this.SushiOrder.Items.Add(this.order.sushis[this.order.sushis.Count - 1]);
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Uramaki":
                        this.order.addToOrder(new Uramaki());
                        this.SushiOrder.Items.Add(this.order.sushis[this.order.sushis.Count - 1]);
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Sashimi":
                        this.order.addToOrder(new Sashimi());
                        this.SushiOrder.Items.Add(this.order.sushis[this.order.sushis.Count - 1]);
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Cheaps":
                        this.order.addToOrder(new Cheaps());
                        this.SushiOrder.Items.Add(this.order.sushis[this.order.sushis.Count - 1]);
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Rolls":
                        this.order.addToOrder(new Rolls());
                        this.SushiOrder.Items.Add(this.order.sushis[this.order.sushis.Count - 1]);
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Deleting selected shushi from order
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void DeleteFromOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String ProductName = (this.SushiOrder.SelectedItem as Sushi).Name;
                switch (ProductName)
                {
                    case "Nigiri":
                        this.order.deleteFromOrder(new Nigiri());
                        this.SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Maki":
                        this.order.deleteFromOrder(new Maki());
                        this.SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Uramaki":
                        this.order.deleteFromOrder(new Uramaki());
                        this.SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Sashimi":
                        this.order.deleteFromOrder(new Sashimi());
                        this.SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Cheaps":
                        this.order.deleteFromOrder(new Cheaps());
                        this.SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                    case "Rolls":
                        this.order.deleteFromOrder(new Rolls());
                        this.SushiOrder.Items.Remove((SushiOrder.SelectedItem as Sushi));
                        this.textBox.Text = this.order.TotalPrice.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// realization of commiting order (save to txt file)
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void commitOrderClick(object sender, RoutedEventArgs e)
        {
            this.order.submitOrder();
            this.textBox.Text = 0.ToString();
            this.SushiOrder.Items.Clear();
        }

        /// <summary>
        /// Loging out as user
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            if (this.order.isSubmitted)
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
