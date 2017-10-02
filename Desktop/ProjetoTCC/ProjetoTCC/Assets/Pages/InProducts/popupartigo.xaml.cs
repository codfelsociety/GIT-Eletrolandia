using BLL;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoTCC.Assets.Pages.InProducts
{
    public partial class popupartigo : Window
    {
        public popupartigo()
        {
            InitializeComponent();
            txtArtigo.Focus();
            DataContext = this;
        }

        
        private string _categoria;
        public string Categoria { get { return _categoria; } set { _categoria = value; }}
        private int _codCategoria;
        public int CodCategoria { get { return _codCategoria; } set { _codCategoria = value; }}
        int i = 0;

        
        public bool Validar(TextBox b)
        {
            if (b.Text.TrimStart().TrimEnd() == "")
            {
                MessageBox.Show("Digite o artigo antes de confirmar");
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(b.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Digite apenas letras");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (Validar(txtArtigo))
            {
                try
                {
                    Artigo.Cadastrar(CodCategoria, txtArtigo.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
                finally
                {
                    MessageBox.Show("Artigo Adicionado", "Tudo certo", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
        }

      
    }
}
