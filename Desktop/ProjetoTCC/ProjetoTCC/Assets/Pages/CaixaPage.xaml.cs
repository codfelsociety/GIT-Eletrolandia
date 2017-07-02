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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void buttonAbrirCaixa_Click(object sender, RoutedEventArgs e)
        {
            frCaixa.Visibility = Visibility.Visible;
            InCaixa.CaixaView c = new InCaixa.CaixaView();
            frCaixa.Navigate(c);
        }
    }
}
