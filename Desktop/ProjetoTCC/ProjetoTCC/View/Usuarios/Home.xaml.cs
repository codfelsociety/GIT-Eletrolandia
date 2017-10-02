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

namespace ProjetoTCC.Assets.Pages.InUsers
{
    /// <summary>
    /// Interaction logic for UsersCover.xaml
    /// </summary>
    public partial class UsersCover : Page
    {
        public UsersCover()
        {
            InitializeComponent();
            icUsuarios.ItemsSource = Usuario.RetornarUsuarioInterface().DefaultView;
        }
        private void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)icUsuarios.SelectedItems[0];
            string info = "";
            info += "\nCod:                "+ row["COD"].ToString();
            info += "\nNome:             "+ row["NOME"].ToString();
            info += "\nEmail:              "+ row["EMAIL"].ToString();
            info += "\nUsername:      "+ row["USERNAME"].ToString();
            info += "\nAcesso:           "+ row["ACESSO"].ToString();
            info += "\nSexo:               "+ row["SEXO"].ToString();
            MessageBox.Show(info);
        }
        public static int COD;
        private void icUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           DataRowView row =  (DataRowView)icUsuarios.SelectedItem;
            COD = (int)row["COD"];
        }
    }
}
