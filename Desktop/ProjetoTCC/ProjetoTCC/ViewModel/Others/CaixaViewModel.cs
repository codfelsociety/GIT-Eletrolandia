using System;
using System.ComponentModel;
using System.Linq;
using BLL;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Navigation;

namespace ProjetoTCC.ViewModel
{
    public class CaixaViewModel : Base
    {
        private Carrinho Carrinho;
        private ICommand confirmar;
        public ICommand Confirmar
        {
            get { return confirmar; }
            set
            { confirmar = value; }
        }
        private ICommand removerItem;
        public ICommand RemoverItem
        {
            get { return removerItem; }
            set
            { removerItem = value; }
        }
        private ICommand openPagamento;
        public ICommand OpenPagamento
        {
            get
            {
                return openPagamento;
            }
            set
            {
                openPagamento = value;
            }
        }

        private int id;
        private int cod_barras;
        private NavigationService nav;
        private int quantidade;
        private string nome;
        private decimal preco;
        private decimal total_item;
        private decimal total;
        private string texto_pesquisa;
        private ObservableCollection<SearchItem> itens_pesquisados;
        private SearchItem item_selecionado_pesquisa;
        private ImageSource imagem;
        private ObservableCollection<ItemProduto> produtosCompra;
        private ItemProduto item_selecionado_carrinho;

        public int Id
        {
            get
            {
                return id;
            }
            set { id = value; RaisePropertyChanged("Id"); }
        }
        public int Cod_barras
        {
            get
            {
                return cod_barras;
            }
            set { cod_barras = value; }
        }
        public int Quantidade
        {
            get
            {
                return quantidade;
            }
            set
            {
                //Ao inserir um novo valor em quantidade
                //Automaticamente atualizar o valor do preço total do item.
                quantidade = value;
                TotalItem = quantidade * Preco;
                RaisePropertyChanged("Quantidade");
            }
        }
        public string Nome
        {
            get
            {
                return nome;
            }
            set { nome = value; RaisePropertyChanged("Nome"); }
        }
        public decimal Preco
        {
            get
            {
                return preco;
            }
            set { preco = value; RaisePropertyChanged("Preco"); }
        }
        public decimal TotalItem
        {
            get
            {
                return total_item;
            }
            set
            {
                total_item = value;
                RaisePropertyChanged("TotalItem");
            }
        }
        public decimal Total
        {
            get
            {
                return total;
            }
            set { total = value; RaisePropertyChanged("Total"); }
        }
        public string TextoPesquisa
        {
            get { return texto_pesquisa; }
            set
            {
                texto_pesquisa = value;
                //Dá acesso aos métodos não estáticos da classe de pesquisa;
                Search searchlist = new Search();
                //Acessa a classe pesquisa chamando o método SearchItens com o parâmetro texto_pesquisa atual
                //Através da compatibilidade new ObservableCollection(List<>), converte a List<SearchItem> em uma coleção.
                //Atribuindo o valor retornado à coleção ItensPesquisados;
                ItensPesquisados = new ObservableCollection<SearchItem>(searchlist.SearchItens(texto_pesquisa));
            }
        }
        public ObservableCollection<SearchItem> ItensPesquisados
        {
            get { return itens_pesquisados; }
            set
            {
                itens_pesquisados = value;
                RaisePropertyChanged("ItensPesquisados");
            }
        }
        public SearchItem ItemSelecionadoPesquisa
        {
            get { return item_selecionado_pesquisa; }
            set
            {
                //Sempre que um novo item for selecionado na pesquisa o atribui à sua propriedade
                item_selecionado_pesquisa = value;
                SetProperties(value.Id, value.Picture, value.Nome, value.Preco, 1);
            }
        }
        public ImageSource Imagem
        {
            get
            {
                return imagem;
            }
            set
            {
                imagem = value;
                RaisePropertyChanged("Imagem");
            }
        }
        public ObservableCollection<ItemProduto> ProdutosCompra
        {
            get
            {
                produtosCompra = new ObservableCollection<ItemProduto>(Carrinho.GetProdutos());
                return produtosCompra;
            }
        }
        public ItemProduto ItemSelecionadoCarrinho
        {
            get
            {
                return item_selecionado_carrinho;
            }
            set
            {
                item_selecionado_carrinho = value;
                SetProperties(value.Id, value.Picture, value.Nome, value.Preco, value.Quantidade);
                RaisePropertyChanged("ItemSelecionadoCarrinho");
            }
        }
        public NavigationService Nav
        {
            get
            {
                return nav;
            }
            set
            {
                nav = value;
                RaisePropertyChanged("Nav");
            }
        }

        public CaixaViewModel(NavigationService nav)
        {
            Confirmar = new RelayCommand(Adicionar);
            RemoverItem = new RelayCommand(Remover);
            OpenPagamento = new RelayCommand(AbrirPagamento);
            Carrinho = new Carrinho();
            Nav = nav;
            Carrinho.ProdutosChanged += new EventHandler(CarrinhoChanged);
        }

        void Adicionar(object o)
        {
            if (JaExisteProduto()) Atualizar();
            else Carrinho.AddItem(new ItemProduto(Id, Nome, Quantidade, Preco, Imagem));
            Total = SomaTotal();
        }

        void Atualizar()
        {
            Carrinho.UpdateItem(Id, Quantidade);
            Total = SomaTotal();
        }

        void Remover(object o)
        {
            Carrinho.DeleteItem(item_selecionado_carrinho);
            Total = SomaTotal();
            SetProperties(0, null, null, 0, 0);
        }
        /// <summary>
        /// Verifica se já existe um produto com o mesmo ID selecionado na lista de compras do caixa.
        /// </summary>
        bool JaExisteProduto()
        {
            bool b = (ProdutosCompra.ToList()).Where(i => i.Id == Id).Count() == 0 ? false : true;
            return b;
        }

        /// <summary>
        /// Atualiza e/ou Atribui de forma rápida as propriedades nativas da tela de caixa
        /// como por exemplo a Imagem, o Nome e o Preço que aparecem na inteface.
        /// </summary>
        void SetProperties(int id, ImageSource imagem, string nome, decimal preco, int quantidade)
        {
            Id = id;
            Imagem = imagem;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        void CarrinhoChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { RaisePropertyChanged("ProdutosCompra"); }));
        }

        decimal SomaTotal()
        {
            decimal total = 0;
            foreach (ItemProduto i in ProdutosCompra.ToList())
            {
                total += i.TotalItem;
            }
            return total;
        }

        void AbrirPagamento(object o)
        {
            Assets.Pages.InCaixa.PaginaDePagamento janela = new Assets.Pages.InCaixa.PaginaDePagamento(Carrinho.GetProdutos(), Total, this);
            Nav.Navigate(janela);
        }

    }

}
