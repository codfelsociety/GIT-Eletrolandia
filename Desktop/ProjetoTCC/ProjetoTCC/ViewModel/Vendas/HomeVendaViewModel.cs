using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCC.ViewModel
{
    public class HomeVendaViewModel : Base
    {
        private ObservableCollection<Model.Venda> venda;
        public ObservableCollection<Model.Venda> Vendas
        {
            get
            {
                return venda;
            }
            set
            {
                venda = value;
                RaisePropertyChanged("Venda");
            }
        }
    }
}
