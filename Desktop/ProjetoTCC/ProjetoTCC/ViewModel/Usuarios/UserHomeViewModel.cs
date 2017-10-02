using ProjetoTCC.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCC.ViewModel
{
    public class UserHomeViewModel : Base
    {
        private DataView listSource;
        public DataView ListSource
        {
            get
            {
                return listSource;
            }
            set
            {
                listSource = value;
                RaisePropertyChanged("ListSource");
            }
        }

        private int selectedId;
        public int SelectedId
        {
            get
            {
                return selectedId;
            }
            set
            {
                selectedId = value;
                SelectedUser = value;
                RaisePropertyChanged("SelectedId");
            }
        }

        public static int SelectedUser = 0;


       
        public UserHomeViewModel()
        {
            ListSource = Usuario.Listar().DefaultView;
        }
    }
}
