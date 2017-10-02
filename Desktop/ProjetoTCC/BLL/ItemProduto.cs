using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BLL
{
    public class ItemProduto : INotifyPropertyChanged
    {
        public ItemProduto(int id, string nome, int quantidade, decimal preco, ImageSource picture)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
            TotalItem = Quantidade * Preco;
            Picture = picture;
        }
        private decimal _totalItem;
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal TotalItem { get { return Quantidade * Preco; } set { _totalItem = value; OnPropertyChanged("TotalItem"); } }
        public ImageSource Picture { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
