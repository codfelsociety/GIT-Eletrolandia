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
using DAO;
using System.Data;

namespace ProjetoTCC.ViewModel
{
    public class VendasViewModel : Base
    {
        private object vendas;
        private object vendaSelecionada;
        private decimal total_hoje;
        private int id_venda;
        private object produtos_venda;

        public decimal TotalHoje
        {
            get
            { return total_hoje; }
            set
            { total_hoje = value; }
        }
        public object Vendas
        {
            get
            {
                return vendas;
            }
            set
            {
                vendas = value;
                RaisePropertyChanged("Vendas");
            }
        }
        public object VendaSelecionada
        {
            get
            {
                return vendaSelecionada;
            }
            set
            {
                vendaSelecionada = value;
                IdVenda = Convert.ToInt32(((DataRowView)value)["ID_VENDA"]);
                ClasseConexao.Conexao();
                ProdutosVenda = ClasseConexao.RetornarDataTable($@"SELECT prod.*, it.QUANTIDADE, it.PRECO_UNIT
FROM ITEM_VENDA it 
JOIN PRODUTOS prod 
ON it.id_produto = prod.cod_produto
WHERE ID_VENDA = {IdVenda}").DefaultView;
                RaisePropertyChanged("VendaSelecionada");
            }
        }

        public int IdVenda
        {
            get
            {

                return id_venda;
            }
            set
            {
                id_venda = value;
                RaisePropertyChanged("IdVenda");
            }
        }

        public object ProdutosVenda
        {
            get
            {
                return produtos_venda;
            }
            set
            {
                produtos_venda = value;
                RaisePropertyChanged("ProdutosVenda");
            }
        }

        public VendasViewModel()
        {
            ClasseConexao.Conexao();
            Vendas = ClasseConexao.RetornarDataTable("SELECT * FROM VENDA").DefaultView;

        }


    }
}
