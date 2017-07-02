using System;
using System.Windows;

namespace ProjetoTCC
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fmPage.Navigate(new Uri("Assets/Pages/MainPage.xaml", UriKind.Relative));

        }
        public void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = (string)FindResource("strSettings");
            fmPage.Navigate(new Uri("Assets/Pages/SettingsPage.xaml", UriKind.Relative));
        }

        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = (string)FindResource("strProducts");
            fmPage.Navigate(new Uri("Assets/Pages/ProductsPage.xaml", UriKind.Relative));
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = (string)FindResource("strOrders");
            fmPage.Navigate(new Uri("Assets/Pages/OrdersPage.xaml", UriKind.Relative));
        }

        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = (string)FindResource("strSuppliers");
            fmPage.Navigate(new Uri("Assets/Pages/SuppliersPage.xaml", UriKind.Relative));
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = (string)FindResource("strUsers");
            fmPage.Navigate(new Uri("Assets/Pages/UsersPage.xaml", UriKind.Relative));
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = (string)FindResource("strHome");
            fmPage.Navigate(new Uri("Assets/Pages/MainPage.xaml", UriKind.Relative));

        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = (string)FindResource("strClients");
            fmPage.Navigate(new Uri("Assets/Pages/ClientsPage.xaml", UriKind.Relative));

        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = (string)FindResource("strSales");
            fmPage.Navigate(new Uri("Assets/Pages/SalesPage.xaml", UriKind.Relative));
        }

        private void btnCaixa_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Caixa";

            fmPage.Navigate(new Uri("Assets/Pages/CaixaPage.xaml", UriKind.Relative));

        }
    }
}
