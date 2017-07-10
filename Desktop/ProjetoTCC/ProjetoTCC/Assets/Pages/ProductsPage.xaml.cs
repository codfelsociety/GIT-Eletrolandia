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
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            CarregarCover();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            InProducts.ProductView.OPR = 'I';
            InProductPage.NavigationService.Navigate(new Uri("Assets/Pages/InProducts/ProductView.xaml", UriKind.Relative));
            if (i > 0)
                InProductPage.NavigationService.Refresh();
            i++;
        }
        int i = 0;
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            InProducts.ProductView.OPR = 'U';
            InProducts.ProductView.COD = InProducts.ProductsCover.COD;
            InProductPage.NavigationService.Navigate(new Uri("Assets/Pages/InProducts/ProductView.xaml", UriKind.Relative));
         if (i > 0)
                InProductPage.NavigationService.Refresh();
            i++; 
        }
        public void CarregarCover()
        {
            InProductPage.NavigationService.Navigate(new Uri("Assets/Pages/InProducts/ProductsCover.xaml", UriKind.Relative));
        }
        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            ApagarProduto();
        }
        private void ApagarProduto()
        {
            try
            {
                MessageBoxResult r = MessageBox.Show("Você REALMENTE, quer apagar esse produto ?", "Preste muita atenção meu caro", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No);
                if (r == MessageBoxResult.Yes)
                {
                    BLL.Produtos prod = new BLL.Produtos();
                    int cod_prod = InProducts.ProductsCover.COD;
                    prod.DeletarProduto(cod_prod, prod.RetornarFrete(cod_prod));
                    InProductPage.NavigationService.Refresh();
                }
            }catch { MessageBox.Show("Selecione o produto antes"); }
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            InProductPage.NavigationService.Navigate(new Uri("Assets/Pages/InProducts/Reports.xaml", UriKind.Relative));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ActualWidth.ToString() + " " + ActualHeight.ToString());

        }
    }
}
