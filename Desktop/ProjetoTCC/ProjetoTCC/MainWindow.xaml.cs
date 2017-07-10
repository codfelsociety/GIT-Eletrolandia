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
            int Acesso = Login.ACESSO;
            if(Acesso == 2)
            {
                btnProdutos.Visibility = Visibility.Collapsed;
                btnSales.Visibility = Visibility.Collapsed;
                btnUsers.Visibility = Visibility.Collapsed;
                btnOrders.Visibility = Visibility.Collapsed;
                btnSuppliers.Visibility = Visibility.Collapsed;
                btnMensagem.Visibility = Visibility.Collapsed;
            }
        }
        public void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Configurações - Temporariamente Desativado";
            fmPage.Navigate(new Uri("Assets/Pages/SettingsPage.xaml", UriKind.Relative));
        }

        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Produtos";
            fmPage.Navigate(new Uri("Assets/Pages/ProductsPage.xaml", UriKind.Relative));
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Entregas";
            fmPage.Navigate(new Uri("Assets/Pages/OrdersPage.xaml", UriKind.Relative));
        }

        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Fornecedores";
            fmPage.Navigate(new Uri("Assets/Pages/SuppliersPage.xaml", UriKind.Relative));
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Usuários";
            fmPage.Navigate(new Uri("Assets/Pages/UsersPage.xaml", UriKind.Relative));
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Página Inicial";
            fmPage.Navigate(new Uri("Assets/Pages/MainPage.xaml", UriKind.Relative));

        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Clientes";
            fmPage.Navigate(new Uri("Assets/Pages/ClientsPage.xaml", UriKind.Relative));

        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Vendas";
            fmPage.Navigate(new Uri("Assets/Pages/SalesPage.xaml", UriKind.Relative));
        }

        private void btnCaixa_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Caixa";

            fmPage.Navigate(new Uri("Assets/Pages/CaixaPage.xaml", UriKind.Relative));

        }

        private void btnMensagem_Click(object sender, RoutedEventArgs e)
        {
            lblOpenedPage.Content = "Mensagem";

            fmPage.Navigate(new Uri("Assets/Pages/Mensagem.xaml", UriKind.Relative));
        }
    }
}
