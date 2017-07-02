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

namespace ProjetoTCC.Assets.Pages
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            this.InProductPage.Navigate(new Uri("Assets/Pages/InUsers/UsersCover.xaml", UriKind.Relative));

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           this.InProductPage.Navigate(new Uri("Assets/Pages/InUsers/UsersView.xaml", UriKind.Relative));
        }

        
    }
}
