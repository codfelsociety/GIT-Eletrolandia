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
using System.Windows.Shapes;
using DAO;
using System.Data;

namespace ProjetoTCC
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        public static int ACESSO;
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Password;
            string SQL = $"SELECT * FROM USUARIO WHERE USERNAME = '{usuario}' AND  SENHA = '{senha}'";
            DataTable dt =  ClasseConexao.RetornarDataTable(SQL);
            if(dt.Rows.Count ==0 )
            {
                MessageBox.Show("Senha e/ou usuário inválidos.","Não foi possível logar.");
            }
            else {

                DataRow r = dt.Rows[0];
                if(Convert.ToInt32(r[1]) == 1) ///1 = Admin   /// 2 - Caixa
                {
                    ACESSO = 1;
                }
                else
                {
                    ACESSO = 2;
                }
                MainWindow m = new MainWindow();
                m.Show();
                Close();
            }
        }
    }
}
