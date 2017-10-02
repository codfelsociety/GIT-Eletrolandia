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
    /// Interação lógica para CaixaPage.xam
    /// </summary>
    public partial class CaixaPage : Page
    {
        public CaixaPage()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new InCaixa.CaixaPageView(null));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
