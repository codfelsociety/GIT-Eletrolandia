using BLL;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ProjetoTCC.Assets.Pages.InSuppliers
{
    /// <summary>
    /// Interaction logic for SuppliersCover.xaml
    /// </summary>
    public partial class SuppliersCover : Page
    {
        public SuppliersCover()
        {
            InitializeComponent();
            Fornecedor forn = new Fornecedor();
             dataGrid1.ItemsSource = forn.Consultar().DefaultView;
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
