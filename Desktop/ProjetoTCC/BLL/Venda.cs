using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;

namespace BLL
{
    public class Venda
    {
        private static string SQL;
        private static OracleCommand cmd;
        private int _codVenda;
        private int _codTipo;
        private int _codEndereco;
        private int _codContato;
        private string _dataVenda;
        private decimal _preco_frete;
        private string _nome;
        private int _tipoPagamento;
        private decimal _valorPagamento;

        public int CodVenda { get => _codVenda; set => _codVenda = value; }
        public int CodTipo { get => _codTipo; set => _codTipo = value; }
        public int CodEndereco { get => _codEndereco; set => _codEndereco = value; }
        public int CodContato { get => _codContato; set => _codContato = value; }
        public string DataVenda { get => _dataVenda; set => _dataVenda = value; }
        public decimal Preco_frete { get => _preco_frete; set => _preco_frete = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public int TipoPagamento { get => _tipoPagamento; set => _tipoPagamento = value; }
        public decimal ValorPagamento { get => _valorPagamento; set => _valorPagamento = value; }

        private void Cadastrar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_venda", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_venda", OracleDbType.Int32).Value = CodVenda;
            cmd.Parameters.Add("p_cod_tipo", OracleDbType.Int32).Value = CodTipo;
            cmd.Parameters.Add("p_cod_endereco", OracleDbType.Int32).Value = CodEndereco;
            cmd.Parameters.Add("p_cod_contato", OracleDbType.Int32).Value = CodContato;
            cmd.Parameters.Add("p_data_venda", OracleDbType.Varchar2).Value = DataVenda;
            cmd.Parameters.Add("p_preco_frete", OracleDbType.Decimal).Value = Preco_frete;
            cmd.Parameters.Add("p_nome", OracleDbType.Varchar2).Value = Nome;
            cmd.Parameters.Add("p_tipo_pagamento", OracleDbType.Int32).Value = TipoPagamento;
            cmd.Parameters.Add("p_valor_pagamento", OracleDbType.Decimal).Value = ValorPagamento;
            cmd.ExecuteNonQuery();

        }
    }
}
