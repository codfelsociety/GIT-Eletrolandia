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
using DAO;
using System.Data;

namespace ProjetoTCC.Assets.Pages
{
    /// <summary>
    /// Interação lógica para Mensagem.xam
    /// </summary>
    public partial class Mensagem : Page
    {
        public Mensagem()
        {
            InitializeComponent();
            string SQL = "SELECT * FROM mensagem";
            dtMensagem.ItemsSource = ClasseConexao.RetornarDataTable(SQL).DefaultView;
        }

        private void dtMensagem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
