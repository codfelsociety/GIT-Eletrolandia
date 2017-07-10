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

namespace ProjetoTCC.Assets.Pages
{
    public partial class SuppliersPage : Page
    {
        int i = 0;
        public SuppliersPage()
        {
            InitializeComponent();
            LoadCover();
        }
        private void LoadCover()
        {
            btnCancelar.Visibility = Visibility.Hidden;
            InSupplierPage.Navigate(new Uri("Assets/Pages/InSuppliers/SuppliersCover.xaml", UriKind.Relative));
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            btnCancelar.Visibility = Visibility.Visible;
            btnAlterar.IsEnabled = false;
            InSupplierPage.Navigate(new Uri("Assets/Pages/InSuppliers/SuppliersView.xaml", UriKind.Relative));
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            InSuppliers.SuppliersUpdate.COD = InSuppliers.SuppliersCover.COD;
            btnCancelar.Visibility = Visibility.Visible;
            btnAlterar.IsEnabled = true;
            InSupplierPage.Navigate(new Uri("Assets/Pages/InSuppliers/SuppliersUpdate.xaml", UriKind.Relative));
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LoadCover();
            btnAlterar.IsEnabled = true;
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Você REALMENTE, quer apagar este fornecedor ?", "Preste muita atenção meu caro", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No);
            if (r == MessageBoxResult.Yes)
            {
                BLL.Fornecedor forn = new BLL.Fornecedor();
                forn.CodFornecedor = InSuppliers.SuppliersCover.COD;
                forn.Apagar();
                InSupplierPage.NavigationService.Refresh();
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
