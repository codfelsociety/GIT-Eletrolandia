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
    /// Interação lógica para CaixaPageView.xam
    /// </summary>
    public partial class CaixaPageView : Page
    {
        object Context = null;
        public CaixaPageView(object datacontext)
        {
            InitializeComponent();
            Context = datacontext;
        }
        
        private void txtPesquisa_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchList.Visibility = Visibility.Visible;
        }
        private void txtPesquisa_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.Sleep(200);
            SearchList.Visibility = Visibility.Hidden;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Context == null)
                DataContext = new ViewModel.CaixaViewModel(NavigationService);
            else DataContext = Context;
        }
    }
}
