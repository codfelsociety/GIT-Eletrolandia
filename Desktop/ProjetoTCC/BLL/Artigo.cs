using System.Data;
using DAO;
using Oracle.DataAccess.Client;

namespace BLL
{
    public class Artigo
    {
        private static string SQL;
        private static OracleCommand cmd;

        public static DataView Load(int CodCategoria = 0)
        {
            if(CodCategoria != 0)
            SQL = "SELECT * FROM ARTIGO WHERE COD_CATEGORIA =" + CodCategoria ;
            else
            SQL = "SELECT * FROM ARTIGO";
            
            DataView dv = ClasseConexao.RetornarDataTable(SQL).DefaultView;
            return dv;
        }
        public static  void Cadastrar(int cod_categoria, string descricao)
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_artigo", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_categoria", OracleDbType.Int32).Value = cod_categoria;
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