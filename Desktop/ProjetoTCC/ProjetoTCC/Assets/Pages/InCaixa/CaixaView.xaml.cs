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

namespace ProjetoTCC.Assets.Pages.InCaixa
{
    public partial class CaixaView : Page
    {
        public CaixaView()
        {
            InitializeComponent();
            listViewPesquisa.Visibility = Visibility.Hidden;
            txtQuantidade.Value = 1;
            dtListaAdicionados.Columns.Add("LOCAL_IMAGEM");
            dtListaAdicionados.Columns.Add("COD_PRODUTO");
            dtListaAdicionados.Columns.Add("NOME");
            dtListaAdicionados.Columns.Add("PRECO_UNIT");
            dtListaAdicionados.Columns.Add("QUANTIDADE");
            dtListaAdicionados.Columns.Add("TOTAL_ITEM");
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                row = (DataRowView)DataGridAdicionados.SelectedItems[0];
                COD = Convert.ToInt32(row["COD_PRODUTO"]);
                NOME = Convert.ToString(row["NOME"]);
                txtQuantidade.Value = Convert.ToInt32(row["QUANTIDADE"]);
                txtNomeProduto.Text = NOME;
                PRECO = ConverterDecimal(row["PRECO_UNIT"].ToString());
                txtPreco.Text = "R$ " + string.Format("{0:#.00}", PRECO);
                txtTotalItem.Text = "R$ " + string.Format("{0:#.00}", PRECO * txtQuantidade.Value);
                LOCAL_IMAGEM = Convert.ToString(row["LOCAL_IMAGEM"]);
                imgProduto.Source = new BitmapImage(new Uri(@LOCAL_IMAGEM));
                btnAdicionar.IsEnabled = true;
            }
            catch (Exception) { }
        }



        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtPesquisa_GotFocus(object sender, RoutedEventArgs e)
        {
            listViewPesquisa.Visibility = Visibility.Visible;

        }

        private void txtPesquisa_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.Sleep(200);

            listViewPesquisa.Visibility = Visibility.Hidden;

        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtPesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            string SQL = $@"SELECT img.local_imagem, prod.nome, prod.cod_produto AS COD, prod.cod_barras, logprod.preco_venda as  PRECO
                                FROM produto prod
                                JOIN 
                                (SELECT inn.* FROM (SELECT log2.*, (ROW_NUMBER() OVER(PARTITION BY cod_produto ORDER BY cod_log_prod DESC)) As Rank 
                                  FROM log_produto log2) inn WHERE inn.Rank=1) logprod
                                ON  prod.cod_produto = logprod.cod_produto
                                LEFT JOIN
                                (SELECT inn.* FROM (SELECT img2.*, (ROW_NUMBER() OVER(PARTITION BY cod_produto ORDER BY local_imagem DESC)) As Rank 
                                FROM imagem_produto img2) inn WHERE inn.Rank=1) img
                                ON prod.cod_produto = img.cod_produto
                                WHERE upper(prod.nome) LIKE upper('%{txtPesquisa.Text.ToString()}%')";
            listViewPesquisa.ItemsSource = DAO.ClasseConexao.RetornarDataTable(SQL).DefaultView;
        }
        public int COD;
        public decimal PRECO;
        public string LOCAL_IMAGEM;
        public string NOME;
        public decimal TOTAL = 0;
        DataRowView row;
        private decimal ConverterDecimal(string wow)
        {
            string entrada = wow;
            string numbers = string.Join("", entrada.ToCharArray().Where(Char.IsDigit));
            return Convert.ToDecimal(numbers) / 100;
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            row = (DataRowView)listViewPesquisa.SelectedItems[0];
            COD = Convert.ToInt32(row["COD"]);
            NOME = Convert.ToString(row["NOME"]);
            txtNomeProduto.Text = NOME;
            PRECO = Convert.ToDecimal(row["PRECO"]);
            txtPreco.Text = "R$ " + string.Format("{0:#.00}", PRECO);
            if(txtQuantidade.Value != 0)
            {
                txtTotalItem.Text = "R$ " + string.Format("{0:#.00}", PRECO * txtQuantidade.Value);
            }
            else
            {
                txtTotalItem.Text = "R$ 0,00";
            }
            LOCAL_IMAGEM = Convert.ToString(row["LOCAL_IMAGEM"]);
            imgProduto.Source = new BitmapImage(new Uri(@LOCAL_IMAGEM));
            btnAdicionar.IsEnabled = true;
        }

        private void txtQuantidade_ValueChanged(object sender, EventArgs e)
        {
            int quant = txtQuantidade.Value;
            if(quant == 0)
            {
                txtTotalItem.Text = "R$ 0,00";
            }
            else if ((int)PRECO == 0) {
                txtTotalItem.Text = "R$ 0,00";
            }
            else
            {
                decimal valor = PRECO * quant;
                txtTotalItem.Text = "R$ " + string.Format("{0:#.00}", valor);
            }
        }
        DataTable dtListaAdicionados = new DataTable();
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuantidade.Value > 0) {
                DataRow ok = null;
                try
                {
                    ok = dtListaAdicionados.Select("COD_PRODUTO = " + COD).FirstOrDefault(); ;
                    if (ok != null)
                    {

                        decimal dec = ConverterDecimal(ok["TOTAL_ITEM"].ToString());
                        ok["QUANTIDADE"] = txtQuantidade.Value;
                        ok["TOTAL_ITEM"] = "R$ " + string.Format("{0:#.00}", PRECO * txtQuantidade.Value);
                        DataGridAdicionados.ItemsSource = dtListaAdicionados.DefaultView;
                        TOTAL -= dec;
                        TOTAL += PRECO * txtQuantidade.Value;
                        lblTotal.Content = "R$ " + string.Format("{0:#.00}", TOTAL);

                    }
                }
                catch (Exception)
                {
                }
                if (ok == null)
                {
                    dtListaAdicionados.Rows.Add(LOCAL_IMAGEM, COD, NOME, "R$ " + string.Format("{0:#.00}", PRECO), txtQuantidade.Value, "R$ " + string.Format("{0:#.00}", PRECO * txtQuantidade.Value));
                    DataGridAdicionados.ItemsSource = dtListaAdicionados.DefaultView;
                    TOTAL += PRECO * txtQuantidade.Value;
                    lblTotal.Content = "R$ " + string.Format("{0:#.00}", TOTAL);
                }
            }
            else
            {
                MessageBox.Show("A Quantidade(Q) deve atender a Q > 0 para que o item seja adicionado/atualizado !", "Something Wrong is not Right",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RemoveItem(int codigo)
        {
            DataRow ok = null;
            ok = dtListaAdicionados.Select("COD_PRODUTO = " + codigo).FirstOrDefault(); 
            if(ok != null)
            {
                dtListaAdicionados.Rows.Remove(ok);
                DataGridAdicionados.ItemsSource = dtListaAdicionados.DefaultView;
            }
            LimparPreview();
        }

        private void LimparPreview()
        {
            imgProduto.Source = null;
            txtPreco.Text = "R$ 0,00";
            PRECO = 0;
            txtNomeProduto.Text = "R$ 0,00";
            txtQuantidade.Value = 1;
            txtTotalItem.Text = " . . .";


        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem(COD);
            btnAdicionar.IsEnabled = false;

        }

        private void currencyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    

}
