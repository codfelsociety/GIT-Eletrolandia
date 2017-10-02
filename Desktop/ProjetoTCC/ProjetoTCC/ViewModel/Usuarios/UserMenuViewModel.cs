using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoTCC.Model;
using System.Windows.Navigation;
using System.Windows.Input;
using ProjetoTCC.Common;

namespace ProjetoTCC.ViewModel
{
    public class UserMenuViewModel : Base
    {

       

        private ICommand adicionar;
        public ICommand Adicionar
        {
            get
            {
                return adicionar;
            }
            set
            { adicionar = value; }
        }

        private ICommand editar;
        public ICommand Editar
        {
            get
            {
                return editar;
            }
            set
            { editar = value; }
        }

        private ICommand apagar;
        public ICommand Apagar
        {
            get
            {
                return apagar;
            }
            set
            { apagar = value; }
        }

        private NavigationService navigation;
        public NavigationService Navigation
        {
            get
            {
                return navigation;
            }
            set
            {
                navigation = value;
                RaisePropertyChanged("Navigation");
            }
        }
        public UserMenuViewModel(NavigationService nav)
        {
            Navigation = nav;
            Navigation.Navigate(new View.Usuarios.Home());
            Adicionar = new RelayCommand(AdicionarEvt);
            Editar = new RelayCommand(EditarEvt);
            Apagar = new RelayCommand(ApagarEvt);
        }

        public void AdicionarEvt(object o)
        {
            Navigation.Navigate(new View.Usuarios.Manage(Navigation));
        }

        public void EditarEvt(object o)
        {
            int code = UserHomeViewModel.SelectedUser;
            Navigation.Navigate(new View.Usuarios.Manage(code, Navigation));

        }
        public void ApagarEvt(object o)
        {
            int dialogResult = Message.Ask("Deseja apagar ou desativar ?", "Apagar", "Desativar");
            int code = UserHomeViewModel.SelectedUser;
            if (dialogResult == 1)
            {
                Usuario user = new Usuario();
                user.Id = code;
                user.Apagar();
            }
            if (dialogResult == 2)
            {
                Usuario user = new Usuario();
                user.Id = code;
                user.Status = 3;
                user.MudarStatus();
            }
            Navigation.Navigate(new View.Usuarios.Home());


        }
    }
}
