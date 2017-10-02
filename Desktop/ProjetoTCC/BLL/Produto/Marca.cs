using System.Data;
using DAO;
using Oracle.DataAccess.Client;

namespace BLL
{
    public class Marca
    {
        private static string SQL;
        private static OracleCommand cmd;

        public static DataView Load()
        {
            SQL = "SELECT COD_MARCA, DESCRICAO FROM MARCA ORDER BY  COD_MARCA";
            DataView dv = ClasseConexao.RetornarDataTable(SQL).DefaultView;

            return dv;
        }
        public static void Cadastrar(string descricao)
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_marca", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_descricao", OracleDbType.Varchar2).Value = descricao;
            cmd.ExecuteNonQuery();
        }
        public void Alterar()
        {

        }
        public void Apagar()
        {

        }
    }
}
