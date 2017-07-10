using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Threading.Tasks;

namespace BLL
{
    public class Contato
    {
        private int _codContato;
        private long _telefone;
        private long _celular;
        private string _email;

        public int CodContato { get => _codContato; set => _codContato = value; }
        public long Telefone { get => _telefone; set => _telefone = value; }
        public long Celular { get => _celular; set => _celular = value; }
        public string Email { get => _email; set => _email = value; }

        private static OracleCommand cmd;
        private string SQL;

        public int ProxCodContato()
        {
            SQL = "SELECT seq_contato.NEXTVAL FROM DUAL";
            return Convert.ToInt32(ClasseConexao.RetornarDataTable(SQL).Rows[0][0]);
        }

        public  void Cadastrar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_contato", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_contato", OracleDbType.Int32).Value = CodContato;
            cmd.Parameters.Add("p_telefone", OracleDbType.Int64).Value = Telefone;
            cmd.Parameters.Add("p_celular", OracleDbType.Int64).Value = Celular;
            cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = Email;
            cmd.ExecuteNonQuery();
        }

        public void Alterar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("update_contato", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_contato", OracleDbType.Int32).Value = CodContato;
            cmd.Parameters.Add("p_telefone", OracleDbType.Int64).Value = Telefone;
            cmd.Parameters.Add("p_celular", OracleDbType.Int64).Value = Celular;
            cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = Email;
            cmd.ExecuteNonQuery();
        }

    }
}
