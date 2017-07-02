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
using BLL;
using System.Data;

namespace ProjetoTCC.Assets.Pages.InProducts
{
    public partial class ProductsCover : Page
    {
        public ProductsCover()
        {
            InitializeComponent();
            Produtos prod = new Produtos();
            dataGrid1.ItemsSource = prod.PreencherTabela().DefaultView;
        }
        public static int count = 0;
        public static int COD;
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            count++;
            COD = (int)((DataRowView)dataGrid1.SelectedItem)[0];
        }

      
    }
}
