using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetoTCC.ViewModel
{
    public class PagamentoViewModel : Base
    {
        #region Venda

        public Venda Venda;

        private ICommand confirmar;
        public ICommand Confirmar
        {
            get { return confirmar; }
            set
            { confirmar = value; }
        }

        private List<ItemProduto> produtos;
        public List<ItemProduto> Produtos
        {
            get
            {
                return produtos;
            }
            set
            {
                produtos = value;
                RaisePropertyChanged("Produtos");
            }
        }

        private decimal total;
        public decimal Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                RaisePropertyChanged("Total");
            }
        }

        private bool status_confirmar;
        public bool StatusConfirmar
        {
            get
            {
                return status_confirmar;
            }
            set
            {
                status_confirmar = value;
                RaisePropertyChanged("StatusConfirmar");
            }
        }

        private string texto_info;
        public string TextoInfo
        {
            get
            {
                return texto_info;
            }
            set
            {
                texto_info = value;
                RaisePropertyChanged("TextoInfo");
            }
        }

        private decimal valor_recebido;
        public decimal ValorRecebido
        {
            get
            {
                return valor_recebido;
            }
            set
            {
                decimal i = 0M;
                if (value < 0) { i = -value; }
                else if (value > 99999.99M) { i = 99999.99M; }
                else { i = value; }
                valor_recebido = i;
                if (i >= Total)
                {
                    TextoInfo = "TROCO:";
                    Troco = i - Total;
                    StatusConfirmar = true;
                }
                else
                {
                    TextoInfo = "FALTAM:";
                    Troco = Total - i;
                    StatusConfirmar = false;
                }
                RaisePropertyChanged("ValorRecebido");
            }
        }

        private decimal troco;
        public decimal Troco
        {
            get
            {
                return troco;
            }
            set
            {
                troco = value;
                RaisePropertyChanged("Troco");
            }
        }


        #endregion

        #region Info/Cliente/Entrega
        private string cpf;
        public string Cpf
        {
            get
            {
                return cpf;
            }
            set
            {
                cpf = value;
                RaisePropertyChanged("Cpf");
            }
        }
        #endregion


        public PagamentoViewModel(List<ItemProduto> itensdacompra, decimal total)
        {
            Confirmar = new RelayCommand(ConfirmarVenda);
            Venda = new Venda();
            Produtos = itensdacompra; Total = total;
            StatusConfirmar = false;
            TextoInfo = "TROCO:";
        }

        public void ConfirmarVenda(object o)
        {
            Venda.Add(Produtos, Cpf);
            System.Windows.MessageBox.Show("Venda Finalizada");
        }


    }
}
