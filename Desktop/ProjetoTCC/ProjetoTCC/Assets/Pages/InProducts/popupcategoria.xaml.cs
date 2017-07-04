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
using BLL;
using System.Windows.Shapes;

namespace ProjetoTCC.Assets.Pages.InProducts
{
    /// <summary>
    /// Lógica interna para popupcategoria.xaml
    /// </summary>
    public partial class popupcategoria : Window
    {
        public popupcategoria()
        {
            InitializeComponent();
        }
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
            if (Validar(txtCategoria))
            {
                try
                {
                    Categoria.Cadastrar(txtCategoria.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
                finally
                {
                    MessageBox.Show("Categoria Adicionada", "Tudo certo", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
        }
    }
}
