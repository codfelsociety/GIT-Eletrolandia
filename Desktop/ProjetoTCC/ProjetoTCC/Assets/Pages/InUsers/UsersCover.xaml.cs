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
            //Funcionarios.CarregarGrid();
           // icUsuarios.ItemsSource = Funcionarios.dtUsuarios.DefaultView;
        }
        private void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)icUsuarios.SelectedItems[0];
            string COD = Convert.ToString(row["COD"]);
            string nome = Convert.ToString(row["NOME"]);
            string sobrenome = Convert.ToString(row["SOBRENOME"]);
            string idade = Convert.ToString(row["IDADE"]);
            string cidade = Convert.ToString(row["CIDADE"]);



            MessageBox.Show( "COD: " + COD + "\nNOME: " + nome + " " + sobrenome + "\n" + "IDADE: " + idade + "\nCIDADE: " + cidade);
            

        }
    }
}
