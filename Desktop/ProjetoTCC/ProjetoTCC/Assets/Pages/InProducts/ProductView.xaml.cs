#region Imports
using System;
using System.Windows;
using System.Windows.Controls;
using BLL;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
#endregion Imports
namespace ProjetoTCC.Assets.Pages.InProducts
{
    public partial class ProductView : Page
    {
        public static char OPR;
        public static int COD;
        int FRETE = 0;
        public ProductView()
        {
            InitializeComponent();
        }

        #region Loads 
        public void LoadInicial()
        {
            if (OPR == 'I')
            {
                txtData.Text = DateTime.Now.ToString();
                txtCod.Text = Produtos.RetornarID(0).ToString().PadLeft(8, '0');
                LoadCategoria();
                cbxCategoria.SelectedIndex = 1;
                LoadArtigo();
                LoadFornecedor();
                LoadMarca();
            }
            if (OPR == 'U')
            {
                Produtos prod = new Produtos();
                prod.CodProduto = COD;
                txtCod.Text = COD.ToString().PadLeft(8, '0');
                DataRow r = prod.PreCarregar()[0].Rows[0];
                txtCodBarras.Text = r[0].ToString();
                txtName.Text = r[1].ToString();
                edtDescricao.Text = r[2].ToString();
                nudEstoque.Value = System.Convert.ToInt32(r[3].ToString());
                nudEstoqueMin.Value = System.Convert.ToInt32(r[4].ToString());
                nudEstoqueMax.Value = System.Convert.ToInt32(r[5].ToString());
                int Ativo = System.Convert.ToInt32(r[6].ToString());
                if (Ativo == 1)
                    chkAtivo.IsChecked = true;
                int Limitado = System.Convert.ToInt32(r[8].ToString());
                if (Limitado == 1)
                    chkLimitado.IsChecked = true;
                int Online = System.Convert.ToInt32(r[7].ToString());
                if (Online == 1)
                    chkOnline.IsChecked = true;
                txtData.Text = System.Convert.ToDateTime(r[9]).ToString();
                LoadCategoria();
                cbxCategoria.SelectedValue = System.Convert.ToInt32(r[11]);
                LoadArtigo();
                cbxArtigo.SelectedValue = System.Convert.ToInt32(r[10]);
                PopulateEspecifications();
                LoadMarca();
                cbxMarca.SelectedValue = System.Convert.ToInt32(r[12]);
                txtCusto.Number = System.Convert.ToDecimal(r[13]);
                txtPreco.Number = System.Convert.ToDecimal(r[14]);
                txtPeso.Text = r[15].ToString();
                txtAltura.Text = r[16].ToString();
                txtComprimento.Text = r[17].ToString();
                txtLargura.Text = r[18].ToString();
                int Fragil = System.Convert.ToInt32(r[19].ToString());
                if (Fragil == 1)
                    chkFragil.IsChecked = true;
                int FreteGratis = System.Convert.ToInt32(r[20].ToString());
                if (FreteGratis == 1)
                    rbFreteSim.IsChecked = true;
                else
                    rbFreteNao.IsChecked = true;
                LoadFornecedor();
                cbxFornecedor.SelectedItems = prod.PreCarregar()[1];
                DataTable imgs = prod.PreCarregar()[2];
                if (imgs != null)
                {
                    List<byte[]> list = new List<byte[]>();
                    foreach (DataRow row in imgs.Rows)
                    {
                        list.Add(row[0] as byte[]);
                    }
                    imagepicker.Source = list;

                }
                foreach (Control ctr in SpecPanel.Children)
                {
                    if (ctr is ComboBox)
                    {
                        string name = ctr.Name;
                        int cod_ESPEC = Convert.ToInt32(ctr.Name.Substring(2, name.Length - 2));
                        (ctr as ComboBox).SelectedValue = prod.RetornarPreValor(cod_ESPEC, COD);
                    }
                }
                FRETE = Convert.ToInt32(r[21]);
            }
        }
        public void LoadMarca()
        {
            int i = cbxMarca.SelectedIndex;
            cbxMarca.DisplayMemberPath = "DESCRICAO";
            cbxMarca.SelectedValuePath = "COD_MARCA";
            cbxMarca.ItemsSource = Marca.Load();
            cbxMarca.SelectedIndex = i;

        }
        public void LoadCategoria()
        {
            int i = cbxCategoria.SelectedIndex;
            cbxCategoria.DisplayMemberPath = "DESCRICAO";
            cbxCategoria.SelectedValuePath = "COD_CATEGORIA";
            cbxCategoria.ItemsSource = Categoria.Load();
            cbxCategoria.SelectedIndex = i;
        }
        public void LoadArtigo()
        {
            int i = cbxArtigo.SelectedIndex;
            if(i < 0)
            {
                i = 0;
            }
            cbxArtigo.SelectedValuePath = "COD_ARTIGO";
            cbxArtigo.DisplayMemberPath = "DESCRICAO";
            cbxArtigo.ItemsSource = Artigo.Load((int)cbxCategoria.SelectedValue);
            cbxArtigo.SelectedIndex = i;

        }
        public void LoadFornecedor()
        {
            cbxFornecedor.SelectedValuePath = "COD_FORNECEDOR";
            cbxFornecedor.DisplayMemberPath = "NOME";
            cbxFornecedor.ItemsSource = Fornecedor.Load();
        }
        #endregion Loads
        #region Selection Changed
        private void cbxMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try { LoadArtigo(); } catch (Exception) { }
        }
        private void cbxArtigo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateEspecifications();
        }
        #endregion Selection Changed
        #region Text Changed
        private void txtCusto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPreco.IsLoaded)
            {
                decimal custo = txtCusto.Number;
                decimal preco = txtPreco.Number;
                if (preco != 0 && custo != 0 && custo < preco)
                {
                    txtCostPercent.Text = "R$" + (preco - custo).ToString() + " (" + Math.Round(((preco - custo) / custo * 100), 0).ToString() + "%)";
                }
                else
                {
                    txtCostPercent.Text = "...";
                }
            }
        }
        #endregion Text Changed
        #region Button Clicks
        private void txtPreco_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCusto.IsLoaded)
            {
                decimal custo = txtCusto.Number;
                decimal preco = txtPreco.Number;
                if (preco != 0 && custo != 0 && custo < preco)
                {
                    txtCostPercent.Text = "R$" + (preco - custo).ToString() + " (" + Math.Round(((preco - custo) / custo * 100), 0).ToString() + "%)";
                }
                else
                {
                    txtCostPercent.Text = "...";
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (Validar())
            {
                try
                {
                    if (OPR == 'I')
                    {
                        SaveInProdutos();
                        MessageBox.Show("Novo produto cadastrado");
                    }
                    if (OPR == 'U')
                    {
                        AlterarProduto();
                        MessageBox.Show("Produto Alterado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Parece que algo de errado não está certo.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
        private bool Validar()
        {
            bool validado = true;
            if (txtName.Text == "")
            {
                txtName.BorderBrush = Brushes.OrangeRed;
                txtName.BorderThickness = new Thickness(1);
                validado = false;
            }
            else
            {
                txtName.BorderThickness = new Thickness(0);
            }
            if (txtCusto.Number >= txtPreco.Number || txtPreco.Number == 0 || txtCusto.Number == 0)
            {
                recValores.Stroke = Brushes.OrangeRed;
                recValores.StrokeThickness = 1;
                Color color = (Color)ColorConverter.ConvertFromString("#FCC1C1");
                Brush vermelho = new SolidColorBrush(color);
                recValores.Fill = vermelho;
                MessageBox.Show("O preço do produto deve ser superior ao custo.");
                validado = false;
               
            }
            else
            {
                recValores.StrokeThickness = 0;
                Color color = (Color)ColorConverter.ConvertFromString("#B8FFC0");
                Brush verde = new SolidColorBrush(color);
                recValores.Fill = verde;
            }
            return validado;
        }
        #endregion Button Clicks
        #region Validation / Preview Entries
        private static bool isTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }
        private static bool isNumberAllowed(string text)
        {
            Regex regex = new Regex("[^a-z]");
            return !regex.IsMatch(text);
        }
        private bool isCostValid()
        {
            if (txtCusto.Number < txtPreco.Number)
                return true;
            else
                return false;
        }
        private void txtName_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
            }
            else if (e.Key == Key.Back || e.Key == Key.Space)
            {
            }
            else
            {
                e.Handled = true;
            }

        }
        private void txtPeso_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Back || e.Key == Key.OemPeriod)
            {
            }
            else
                e.Handled = true;
        }
        private void txtLargura_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Back || e.Key == Key.OemPeriod)
            {
            }
            else
                e.Handled = true;
        }
        private void txtComprimento_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Back || e.Key == Key.OemPeriod)
            {
            }
            else
                e.Handled = true;
        }
        private void txtAltura_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Back || e.Key == Key.OemPeriod)
            {
            }
            else
                e.Handled = true;
        }
        private void txtCodBarras_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !isTextAllowed(e.Text);
        }

        private void checkNull()
        {
            if (
               (txtCodBarras.Text.Trim() == "") ||
               (txtName.Text.Trim() == "") ||
               (txtCusto.Text.Trim() == "") ||
               (txtPreco.Text.Trim() == "") ||
               (nudEstoque.Value == 0) ||
               (cbxArtigo.SelectedValue == null) ||
               (cbxCategoria.SelectedValue == null) ||
               (cbxFornecedor.SelectedItems == null) ||
               (cbxMarca.SelectedValue == null))
            {
                MessageBox.Show("Preencha Todos os Campos Obrigatórios");
            }
        }
        #endregion Validation
        #region Common Functions and Methods
        private void PopulateEspecifications()
        {
            SpecPanel.Children.Clear();
            int cod_Artigo_Selecionado = System.Convert.ToInt32(cbxArtigo.SelectedValue);
            Produtos.CarregarEspecs(cod_Artigo_Selecionado);
            foreach (DataRow row in Produtos.dtEspecs.Rows)
            {
                Label lbl = new Label();
                lbl.Content = row[1].ToString().ToUpper() + ":";
                SpecPanel.Children.Add(lbl);
                if (System.Convert.ToInt32(row["TIPO"]) == 1)
                {
                    Produtos.CarregarPreEspecValues(System.Convert.ToInt32(row["COD_ESPEC"]));
                    ComboBox cbx = new ComboBox();
                    cbx.Name = "cb" + (row[0].ToString());
                    cbx.ItemsSource = Produtos.dtPreEspecs.DefaultView;
                    SpecPanel.Children.Add(cbx);
                }
                else
                {
                    TextBox txt = new TextBox();
                    txt.Name = ("txt" + row[1].ToString()).Replace(" ", string.Empty);
                    SpecPanel.Children.Add(txt);
                }
            }
        }
        private int SalvarFrete()
        {
            Frete frete = new Frete();
            frete.Peso = System.Convert.ToDouble(txtPeso.Text);
            frete.Altura = System.Convert.ToDouble(txtAltura.Text);
            frete.Comprimento = System.Convert.ToDouble(txtComprimento.Text);
            frete.Largura = System.Convert.ToDouble(txtLargura.Text);
            frete.IsFree = (rbFreteSim.IsChecked == true) ? 1 : 0;
            frete.IsFragile = (chkFragil.IsChecked == true) ? 1 : 0;
            int codFrete = 0;
            if (OPR == 'I')
            {
                codFrete = frete.IDFrete();
                frete.CodFrete = codFrete;
                frete.Cadastrar();
            }
            if (OPR == 'U')
            {
                frete.CodFrete = FRETE;
                frete.Alterar();
            }
            return codFrete;
        }
        Produtos prod = new Produtos();
        private void AlterarProduto()
        {
            prod.CodProduto = COD;
            prod.CodArtigo = (int)cbxArtigo.SelectedValue;
            prod.CodMarca = System.Convert.ToInt32(cbxMarca.SelectedValue);
            prod.CodBarras = System.Convert.ToInt32(txtCodBarras.Text);
            prod.Nome = txtName.Text;
            prod.Limitado = (chkLimitado.IsChecked == true) ? 1 : 0;
            prod.Online = (chkOnline.IsChecked == true) ? 1 : 0;
            prod.LocalDescricao = edtDescricao.Text;
            prod.Estoque = nudEstoque.Value;
            prod.EstoqueMin = nudEstoqueMin.Value;
            prod.EstoqueMax = nudEstoqueMax.Value;
            prod.CodStatus = (chkAtivo.IsChecked == true) ? 1 : 0;
            prod.Fornecedores = cbxFornecedor.SelectedItems;
            prod.Custo = txtCusto.Number;
            prod.Preco = txtPreco.Number;
            DataTable dtimg = new DataTable();
            dtimg.Columns.Add("cod", typeof(int));
            dtimg.Columns.Add("img", typeof(byte[]));
            foreach(byte[] img in imagepicker.Source)
            {
                dtimg.Rows.Add(COD, img);
            }
            prod.ImagemProduto = dtimg;
            prod.AtualizarProduto();
            CadastrarEspecificacoes();
            SalvarFrete();
        }
        private void SaveInProdutos()
        {
            prod.CodProduto = Produtos.RetornarID(1);
            prod.CodArtigo = (int)cbxArtigo.SelectedValue;
            prod.CodMarca = Convert.ToInt32(cbxMarca.SelectedValue);
            prod.CodFrete = SalvarFrete();
            prod.CodBarras = Convert.ToInt32(txtCodBarras.Text);
            prod.Nome = txtName.Text;
            prod.Limitado = (chkLimitado.IsChecked == true) ? 1 : 0;
            prod.Online = (chkOnline.IsChecked == true) ? 1 : 0;
            prod.LocalDescricao = edtDescricao.Text;
            prod.Estoque = nudEstoque.Value;
            prod.EstoqueMin = nudEstoqueMin.Value;
            prod.EstoqueMax = nudEstoqueMax.Value;
            prod.CodStatus = (chkAtivo.IsChecked == true) ? 1 : 0;
            prod.DataCadastro = DateTime.Now.ToString();
            prod.Fornecedores = cbxFornecedor.SelectedItems;
            prod.Custo = txtCusto.Number;
            prod.Preco = txtPreco.Number;
            DataTable dtimg = new DataTable();
            dtimg.Columns.Add("cod", typeof(int));
            dtimg.Columns.Add("img", typeof(byte[]));
            foreach (byte[] img in imagepicker.Source)
            {
                dtimg.Rows.Add(COD, img);
            }
            prod.ImagemProduto = dtimg;
            CadastrarEspecificacoes();
            prod.Cadastrar();
        }
        private void CadastrarEspecificacoes()
        {
            foreach (Control ctr in SpecPanel.Children)
            {
                if (ctr is ComboBox)
                {
                    int cod_PRE = System.Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                    string name = ((ComboBox)ctr).Name;
                    int cod_ESPEC = System.Convert.ToInt32(((ComboBox)ctr).Name.Substring(2, name.Length - 2));
                    prod.CadastrarEspecs(cod_ESPEC, cod_PRE);
                }
            }
        }
        #endregion Common Functions and Methods

        private void test_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Limpar()
        {
            txtName.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            txtCodBarras.Text = "";
            txtComprimento.Text = "";
            txtCusto.Text = "";
            txtPreco.Text = "";
            txtLargura.Text = "";
            nudEstoque.Value = 0;
            nudEstoqueMin.Value = 0;
            nudEstoqueMax.Value = 0;
            imagepicker.Source = null;
        }
        private void Button_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbxFornecedor_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInicial();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(master.ActualWidth.ToString() + " " + master.ActualHeight.ToString());

        }

        private void btnNovaCategoria_Click(object sender, RoutedEventArgs e)
        {
            popupcategoria p = new popupcategoria();
            p.Show();
        }

        private void cbxCategoria_DropDownOpened(object sender, EventArgs e)
        {
            LoadCategoria();
        }

        private void btnnovoartigo_Click(object sender, RoutedEventArgs e)
        {
            popupartigo p = new popupartigo();
            p.CodCategoria = (int)cbxCategoria.SelectedValue;
            DataRowView dv = (DataRowView)cbxCategoria.SelectedItem;
            p.Categoria = dv[1].ToString();
            p.Show();
        }

        private void cbxArtigo_DropDownOpened(object sender, EventArgs e)
        {
            LoadArtigo();
        }

        private void btnAdicionarNovaMarca_Click(object sender, RoutedEventArgs e)
        {
            popupmarca p = new popupmarca();
            p.Show();
        }

        private void cbxMarca_DropDownOpened(object sender, EventArgs e)
        {
            LoadMarca();
        }
    }
}

