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

namespace ProjetoTCC.View.Usuarios
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
            frameUsuario.Navigate(new Uri("View/Usuarios/Home.xaml", UriKind.Relative));

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            btnCancelar.Visibility = Visibility.Visible;
            frameUsuario.NavigationService.Navigate(new Add());
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameUsuario.Navigate(new Uri("View/Usuarios/Home.xaml", UriKind.Relative));
            btnCancelar.Visibility = Visibility.Hidden;
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            btnCancelar.Visibility = Visibility.Visible;
            int code = 61;
            frameUsuario.Navigate(new Edit(code));
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Confirmar exclusão de usuário ?", "Preste muita atenção meu caro", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No);
            if (r == MessageBoxResult.Yes)
            {
                try
                {
                    BLL.Usuario user = new BLL.Usuario();
                   // user.CodUsuario = InUsers.UsersCover.COD;
                    user.Apagar();
                    frameUsuario.Refresh();
                }
                catch
                {
                    MessageBox.Show("Você deve selecionar um usuário antes de tentar apagar...");
                }
            }
        }
    }
}
