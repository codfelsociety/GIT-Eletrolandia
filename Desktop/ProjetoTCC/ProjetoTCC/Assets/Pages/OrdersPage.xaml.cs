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

namespace ProjetoTCC.Assets.Pages
{
    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
          /*  string SQL = $@"SELECT entrega.cod_tipo,info.nome || ' '|| info.sobrenome AS Nome,
                                info.sexo, info.cpf, info_contato.telefone, info_contato.email,  
                                endereço.cidade, endereço.estado, endereço.número, endereço.tipo
                                FROM entrega
                                JOIN info
                                ON entrega.cod_info = info.cod_info
                                JOIN info_contato
                                ON entrega.cod_contato = info_contato.cod_info_contato
                                JOIN endereço 
                                ON entrega.cod_endereco = endereço.cod_endereço";

            DataView dv = DAO.ClasseConexao.RetornarDataTable(SQL).DefaultView;
     
            DataGridEntregas.ItemsSource =  dv;*/

        }

   
    }
}
