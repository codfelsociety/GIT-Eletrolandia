using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Oracle.DataAccess.Client;
using System.Data;

namespace BLL
{
    public class Endereco
    {
        private int _codEndereco;
        private int _tipo;
        private long _cep;
        private int _cidade;
        private int _estado;
        private string _bairro;
        private string _rua;
        private int _numero;
        private string _complemento;

        public int CodEndereco { get { return _codEndereco; } set { _codEndereco = value; } }
        public int Tipo { get { return _tipo; } set { _tipo = value; } }
        public long Cep { get { return _cep; } set { _cep = value; } }
        public int Cidade { get { return _cidade; } set { _cidade = value; } }
        public int Estado { get { return _estado; } set { _estado = value; } }
        public string Bairro { get { return _bairro; } set { _bairro = value; } }
        public string Rua { get { return _rua; } set { _rua = value; } }
        public int Numero { get { return _numero; } set { _numero = value; } }
        public string Complemento { get { return _complemento; } set { _complemento = value; } }

        private static OracleCommand cmd;
        private string SQL;

        public int ProxCodEndereco()
        {
            SQL = "SELECT seq_endereco.NEXTVAL FROM DUAL";
            return Convert.ToInt32(ClasseConexao.RetornarDataTable(SQL).Rows[0][0]);
        }

        public void Cadastrar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_endereco", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_endereco", OracleDbType.Int32).Value = CodEndereco;
            cmd.Parameters.Add("p_tipo", OracleDbType.Int32).Value = Tipo;
            cmd.Parameters.Add("p_cep", OracleDbType.Int64).Value = Cep;
            cmd.Parameters.Add("p_cidade", OracleDbType.Int32).Value = Cidade;
            cmd.Parameters.Add("p_estado", OracleDbType.Int32).Value = Estado;
            cmd.Parameters.Add("p_bairro", OracleDbType.Varchar2).Value = Bairro;
            cmd.Parameters.Add("p_rua", OracleDbType.Varchar2).Value = Rua;
            cmd.Parameters.Add("p_numero", OracleDbType.Int32).Value = Numero;
            cmd.Parameters.Add("p_complemento", OracleDbType.Varchar2).Value = Complemento;
            cmd.ExecuteNonQuery();
        }
        public void Alterar()
        {
            ClasseConexao.Conexao();

            cmd = new OracleCommand("update_endereco", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_endereco", OracleDbType.Int32).Value = CodEndereco;
            cmd.Parameters.Add("p_tipo", OracleDbType.Int32).Value = Tipo;
            cmd.Parameters.Add("p_cep", OracleDbType.Int64).Value = Cep;
            cmd.Parameters.Add("p_cidade", OracleDbType.Int32).Value = Cidade;
            cmd.Parameters.Add("p_estado", OracleDbType.Int32).Value = Estado;
            cmd.Parameters.Add("p_bairro", OracleDbType.Varchar2).Value = Bairro;
            cmd.Parameters.Add("p_rua", OracleDbType.Varchar2).Value = Rua;
            cmd.Parameters.Add("p_numero", OracleDbType.Int32).Value = Numero;
            cmd.Parameters.Add("p_complemento", OracleDbType.Varchar2).Value = Complemento;
            cmd.ExecuteNonQuery();
        }
       
    }
}
