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

        private int _idVenda;
        private int _idInfo;
        private int _idCliente;
        private string _dataVenda;
        private int _tipo;

        public int IdVenda { get { return _idVenda; } set { _idVenda = value; } }
        public int IdInfo { get { return _idInfo; } set { _idInfo = value; } }
        public int IdCliente { get { return _idCliente; } set { _idCliente = value; } }
        public string DataVenda { get { return _dataVenda; } set { _dataVenda = value; } }
        public int Tipo { get { return _tipo; } set { _tipo = value; } }

        private void ProximoIdVenda()
        {
            SQL = "SELECT SEQ_VENDA.NEXTVAL FROM DUAL";
            IdVenda =  Convert.ToInt32(ClasseConexao.RetornarDataTable(SQL).Rows[0][0]);
        }

        public void Add(List<ItemProduto> produtos, string cpf)
        {
            ProximoIdVenda();
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_venda", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_id_venda", OracleDbType.Int32).Value = IdVenda;
            cmd.Parameters.Add("p_id_tipo", OracleDbType.Int32).Value = 1;
            cmd.Parameters.Add("p_id_cliente", OracleDbType.Int32).Value = 0;
            cmd.Parameters.Add("p_id_info", OracleDbType.Int32).Value = 0;
            cmd.Parameters.Add("p_data_venda", OracleDbType.Varchar2).Value = DateTime.Now;

            cmd.ExecuteNonQuery();
            foreach (ItemProduto item in produtos)
            {
                ClasseConexao.Conexao();
                cmd = new OracleCommand("insert_item_venda", ClasseConexao.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_venda", OracleDbType.Int32).Value = IdVenda;
                cmd.Parameters.Add("p_id_produto", OracleDbType.Int32).Value = item.Id;
                cmd.Parameters.Add("p_preco_unit", OracleDbType.Decimal).Value = item.Preco;
                cmd.Parameters.Add("p_quantidade", OracleDbType.Int32).Value = item.Quantidade;
                cmd.ExecuteNonQuery();
            }

        }
    }
}
