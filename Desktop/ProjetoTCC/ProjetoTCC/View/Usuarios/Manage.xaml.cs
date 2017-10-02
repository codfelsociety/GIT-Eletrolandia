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
    /// Interação lógica para Edit.xam
    /// </summary>
    public partial class Manage : Page
    {
        public Manage(int cod, NavigationService nav)
        {
            InitializeComponent();
            DataContext = new ViewModel.UserViewModel(cod,nav);
        }

        public Manage(NavigationService nav)
        {
            InitializeComponent();
            DataContext = new ViewModel.UserViewModel(nav);
        }
    }
}
