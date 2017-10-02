using BLL;
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

namespace ProjetoTCC.Assets.Pages.InCaixa
{
    /// <summary>
    /// Interação lógica para PaginaDePagamento.xam
    /// </summary>
    public partial class PaginaDePagamento : Page
    {
        object ExternalContext;
        public PaginaDePagamento(List<ItemProduto> compra, decimal total, object context)
        {
            InitializeComponent();
            DataContext = new ViewModel.PagamentoViewModel(compra, total);
            ExternalContext = context;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new CaixaPageView(ExternalContext));
        }

        private void btnDinheiro_Click(object sender, RoutedEventArgs e)
        {
            if (gridVista.Visibility == Visibility.Hidden)
            gridVista.Visibility = Visibility.Visible;
            else gridVista.Visibility = Visibility.Hidden;

        }
    }
}
