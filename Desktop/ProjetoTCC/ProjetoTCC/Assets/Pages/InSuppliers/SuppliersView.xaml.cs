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
namespace ProjetoTCC.Assets.Pages.InSuppliers
{
    /// <summary>
    /// Interaction logic for SuppliersView.xaml
    /// </summary>
    public partial class SuppliersView : Page
    {
        public SuppliersView()
        {
            InitializeComponent();
            LoadEstado();
        }
        public void LoadEstado()
        {
            cbEstado.ItemsSource = Estado.Carregar().DefaultView;
        }
        public void LoadCidade()
        {
            cbCidade.ItemsSource = Cidade.Carregar(Convert.ToInt32(cbEstado.SelectedValue)).DefaultView;
            cbCidade.SelectedIndex = 0;
        }
        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadCidade();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        #region Alterar
        private void AlterarFornecedor()
        {
            Fornecedor forn = new Fornecedor();
            forn.CodEndereco = CadastrarEndereco();
            forn.CodContato = CadastrarContato();
            forn.Nome = txtNome.Text;
            forn.Cnpj = new String(txtCNPJ.Text.Where(Char.IsNumber).ToArray());
            forn.InsEstadual = new String(txtEstadual.Text.Where(Char.IsNumber).ToArray());
            forn.Descricao = txtDescricao.Text;
            forn.Alterar();
        }
        #endregion Alterar
        #region Cadastrar
        private void CadastrarFornecedor()
        {
            Fornecedor forn = new Fornecedor();
            forn.CodEndereco = CadastrarEndereco();
            forn.CodContato = CadastrarContato();
            forn.Nome = txtNome.Text;
            forn.Cnpj = new String(txtCNPJ.Text.Where(Char.IsNumber).ToArray());
            forn.InsEstadual = new String(txtEstadual.Text.Where(Char.IsNumber).ToArray());
            forn.Descricao = txtDescricao.Text;
            forn.Cadastrar();
        }
        private int CadastrarEndereco()
        {
            Endereco end = new Endereco();
            int cod = end.ProxCodEndereco();
            end.CodEndereco = cod;
            end.Cidade = Convert.ToInt32(cbCidade.SelectedValue);
            end.Estado = Convert.ToInt32(cbEstado.SelectedValue);
            end.Tipo = 1;
            end.Bairro = txtBairro.Text;
            end.Numero = nudNumero.Value;
            end.Rua = txtRua.Text;
            end.Cep = new String(txtCep.Text.Where(Char.IsNumber).ToArray());
            end.Complemento = "";
            end.Cadastrar();
            return cod;
        }
        private int CadastrarContato()
        {
            Contato con = new Contato();
            int cod = con.ProxCodContato();
            con.CodContato = cod;
            con.Telefone = Convert.ToInt32(new String(txtTelefone.Text.Where(Char.IsNumber).ToArray()));
            con.Celular = Convert.ToInt32(new String(txtCelular.Text.Where(Char.IsNumber).ToArray()));
            con.Email = txtEmail.Text;
            con.Cadastrar();
            return cod;
        }
        #endregion Cadastrar
    }
}
