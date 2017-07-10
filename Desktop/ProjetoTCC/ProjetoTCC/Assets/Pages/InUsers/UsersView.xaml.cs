using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using BLL;
using System.Windows.Shapes;
using DAO;

namespace ProjetoTCC.Assets.Pages.InUsers
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : Page
    {
        public UsersView()
        {
            InitializeComponent();
            txtID.Text = Usuario.PreverProxID().ToString().PadLeft(8, '0');
            txtDataCadastro.Text = DateTime.Now.ToString();
            string cmd = "SELECT cod_acesso as COD, descricao from acesso";
            cbAcesso.ItemsSource = ClasseConexao.RetornarDataTable(cmd).DefaultView;
        }


        private void CadastrarUsuario()
        {
            Usuario user = new Usuario();
            user.CodUsuario = user.RetornarProxID();
            user.Nome = txtNome.Text;
            user.Sobrenome = txtSobrenome.Text;
            if (rbMasculino.IsChecked == true) { user.Sexo = 1; }
            if (rbFeminino.IsChecked == true) { user.Sexo = 2; }
            user.Acesso = (int)cbAcesso.SelectedValue;
            user.Email = txtEmail.Text;
            user.Senha = txtSenha.Password;
            user.Picture = imgUsuario.SelectedPaths;
            user.Username = txtUsuario.Text;
            user.DataCadastro = DateTime.Now.ToString();
            user.Cadastrar();
        }



        private void Limpar()
        {
            txtNome.Text = "";
            txtSobrenome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Password = "";
            txtConfirmaSenha.Password = "";
            txtEmail.Text = "";
            txtNome.Focus();
        }
        private bool Validar()
        {
            bool r = true;
            string info = "";
            if (txtNome.Text.Trim() == "")
            {
                makeInvalid(txtNome);
                info += "Digite o nome.\n";
                r = false;
            }
            else { makeValid(txtNome); }
            if (txtSobrenome.Text.TrimStart().TrimEnd() == "")
            {
                makeInvalid(txtSobrenome);
                info += "Digite o sobrenome.\n";
                r = false;
            }
            else { makeValid(txtSobrenome); }
            if (txtUsuario.Text.Trim() == "")
            {
                makeInvalid(txtUsuario);
                info += "Digite o usuário.\n";
                r = false;
            }
            else { makeValid(txtUsuario); }
            if (txtSenha.Password.Trim() == "")
            {
                makeInvalid(txtSenha);
                info += "Digite a senha.\n";
                r = false;
            }
            else
            {
                if (txtSenha.Password.Length < 8)
                {
                    makeInvalid(txtConfirmaSenha);
                    info += "A senha deve ter pelo menos 8 digitos.\n";
                    r = false;
                }
                else
                {
                    makeValid(txtConfirmaSenha);
                }
            }
            if (txtEmail.Text.Trim() != "")
            {
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (!regex.IsMatch(txtEmail.Text))
                {
                    makeInvalid(txtEmail);
                    info += "E-mail invalido";
                    r = false;
                }
                else
                {
                    makeValid(txtEmail);
                }
            }

            if (txtSenha.Password.Trim() != "" && txtConfirmaSenha.Password.Trim() == "")
            {
                makeInvalid(txtConfirmaSenha);
                info += "Confirme a senha.\n";
                r = false;
            }
            else
            {
                makeValid(txtConfirmaSenha);
            }

            if (txtSenha.Password.Trim() != "" && txtConfirmaSenha.Password.Trim() != "")
            {
                if (txtConfirmaSenha.Password != txtSenha.Password)
                {
                    recSenhas.Stroke = Brushes.Red;
                    recSenhas.StrokeThickness = 1;
                    info += "As senhas não coincidem.\n";
                    r = false;
                }
                else
                {
                    recSenhas.StrokeThickness = 0;
                }
            }
            if (info != "")
            {
                MessageBox.Show(info);
            }
            return r;
        }
        private void makeValid(Control ctrl)
        {
            ctrl.BorderThickness = new Thickness(0);
        }
        private void makeInvalid(Control ctrl)
        {
            ctrl.BorderThickness = new Thickness(1);
            ctrl.BorderBrush = Brushes.Red;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                try
                {
                    CadastrarUsuario();
                    MessageBox.Show("Novo Usuário Cadastrado", "Perfeito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch { MessageBox.Show("Adicione a foto para cadastrar"); }
                finally { Limpar(); }
            }
        }

    }
}
