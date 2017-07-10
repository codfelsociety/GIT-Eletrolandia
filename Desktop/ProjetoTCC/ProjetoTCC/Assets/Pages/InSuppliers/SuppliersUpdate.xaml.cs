using BLL;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace ProjetoTCC.Assets.Pages.InSuppliers
{
    /// <summary>
    /// Interação lógica para SuppliersUpdate.xam
    /// </summary>
    public partial class SuppliersUpdate : Page
    {
        Fornecedor forn = new Fornecedor();
        public SuppliersUpdate()
        {
            InitializeComponent();
            LoadEstado();
            PreenchimentoInicial();

        }
        public static int COD;

        public void LoadEstado()
        {
            cbEstado.ItemsSource = Estado.Carregar().DefaultView;
        }
        public void LoadCidade()
        {
            cbCidade.ItemsSource = Cidade.Carregar(Convert.ToInt32(cbEstado.SelectedValue)).DefaultView;
        }


        private void Limpar()
        {
            txtNome.Text = "";
            txtBairro.Text = "";
            txtCep.Text = "";
            txtCNPJ.Text = "";
            txtEstadual.Text = "";
            txtDescricao.Text = "";
            txtEmail.Text = "";
            txtRua.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            nudNumero.Value = 0;
            cbEstado.SelectedIndex = 0;
            txtNome.Focus();
        }
        #region Alterar
        private void AlterarFornecedor()
        {
            forn.Nome = txtNome.Text;
            forn.Cnpj = Convert.ToInt64(new String(txtCNPJ.Text.Where(Char.IsNumber).ToArray()));
            forn.InsEstadual = Convert.ToInt64(new String(txtEstadual.Text.Where(Char.IsNumber).ToArray()));
            forn.Descricao = txtDescricao.Text;
            forn.Alterar(); 
        }
        public void AlterarEndereco()
        {
            Endereco end = new Endereco();
            end.CodEndereco = Convert.ToInt32(row["cod_endereco"]);
            end.Cidade = Convert.ToInt32(cbCidade.SelectedValue);
            end.Estado = Convert.ToInt32(cbEstado.SelectedValue);
            end.Tipo = 1;
            end.Bairro = txtBairro.Text;
            end.Numero = nudNumero.Value;
            end.Rua = txtRua.Text;
            end.Cep = Convert.ToInt64(new String(txtCep.Text.Where(Char.IsNumber).ToArray()));
            end.Complemento = "";
            end.Alterar();
        }
        public void AlterarContato()
        {
            Contato con = new Contato();
            con.CodContato = Convert.ToInt32(row["cod_contato"]);
            con.Telefone = Convert.ToInt64(new String(txtTelefone.Text.Where(Char.IsNumber).ToArray()));
            con.Celular = Convert.ToInt64(new String(txtCelular.Text.Where(Char.IsNumber).ToArray()));
            con.Email = txtEmail.Text;
            con.Alterar();
        }
        #endregion Alterar
        int i = 0;
        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadCidade();
        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {

                    AlterarFornecedor();
                    AlterarEndereco();
                    AlterarContato();
                    MessageBox.Show("Fornecedor Alterado", "Everything is fine", MessageBoxButton.OK, MessageBoxImage.Information);
              
            }
        }
        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            Limpar();
        }
        private bool Validar()
        {
            bool r = true;
            if (txtNome.Text.TrimEnd().TrimStart() == "")
            {
                txtNome.BorderThickness = new Thickness(1);
                txtNome.BorderBrush = Brushes.Red;
                MessageBox.Show("Digite o nome do fornecedor");
                r = false;
            }
            else
            {
                txtEmail.BorderThickness = new Thickness(0);
            }
            if (txtEmail.Text.Trim() != "")
            {
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (!regex.IsMatch(txtEmail.Text))
                {
                    txtEmail.BorderThickness = new Thickness(1);
                    txtEmail.BorderBrush = Brushes.Red;
                    MessageBox.Show("E-mail invalido");
                    r = false;
                }
                else
                {
                    txtEmail.BorderThickness = new Thickness(0);
                }
            }
            return r;
        }

        DataTable dtpi = new DataTable();
        DataRow row;
        private void PreenchimentoInicial()
        {
            forn.CodFornecedor = COD;
            dtpi = forn.ConsultarCod();
            row = dtpi.Rows[0];
            txtNome.Text = row["nome"].ToString();
            txtCNPJ.Text = row["cnpj"].ToString();
            txtEstadual.Text = row["ins_estadual"].ToString();
            txtCep.Text = row["cep"].ToString();
            cbEstado.SelectedValue = Convert.ToInt32(row["estado"]);
            cbCidade.SelectedValue = Convert.ToInt32(row["cidade"]);
            txtBairro.Text = row["bairro"].ToString();
            txtRua.Text = row["rua"].ToString();
            nudNumero.Value = Convert.ToInt32(row["numero"]);
            txtEmail.Text = row["email"].ToString();
            txtCelular.Text = row["celular"].ToString();
            txtTelefone.Text = row["telefone"].ToString();
            txtDescricao.Text = row["descricao"].ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void cbCidade_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}

