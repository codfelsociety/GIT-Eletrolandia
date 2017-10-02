using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Carrinho
    {
        public event EventHandler ProdutosChanged;

        List<ItemProduto> Produtos { get; set; }

        public Carrinho()
        {
            Produtos = new List<ItemProduto>();
        }
        public List<ItemProduto> GetProdutos()
        {
            return Produtos;
        }
        public void AddItem(ItemProduto produto)
        {
            Produtos.Add(produto);
            OnProdutosChanged();
        }

        public void DeleteItem(ItemProduto produto)
        {
            Produtos.Remove(produto);
            OnProdutosChanged();
        }
        public void UpdateItem(int id, int quantidade)
        {
            var produto = Produtos.Where(d => d.Id == id).First();
            if (produto != null) { produto.Quantidade = quantidade; produto.TotalItem = quantidade * produto.Preco; }
            OnProdutosChanged();
        }
        void OnProdutosChanged()
        {
            ProdutosChanged?.Invoke(this, null);
        }
    }
}
