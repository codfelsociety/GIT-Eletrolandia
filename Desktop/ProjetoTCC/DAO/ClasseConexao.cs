using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace DAO
{
    public class ClasseConexao
    {
        public static string strConexao = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID=XE)));User ID=ADM;Password=123456";
        public static OracleConnection connection = new OracleConnection(strConexao);
        private static OracleCommand cmd;
        private static OracleDataAdapter da;
        private static DataSet ds;
        private static string SQL;

       /*private static OracleDataReader dr;
          private static OracleParameter p;
          private static OracleParameter q;
          private static string dado;
          private static DataTable dt;*/

        public static string Conexao()
        {
            string info = "";
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    info = "Conectado com a Versão Oracle " + connection.ServerVersion + " Utilizando a fonte " + connection.DataSource;
                }
            }
            catch (OracleException ex)
            {
                return ex.Message;
            }
            return info + " Estado da Conexao " + connection.State.ToString() + " OK";
        }
        public static void FinalizarConexao()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static DataTable RetornarDataTable(string command)
        {
            Conexao();
            cmd = new OracleCommand(command, connection);
            cmd.CommandType = CommandType.Text;
            da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
          //  FinalizarConexao();
            return ds.Tables[0];
        }
        public void ExecutarComando(string sqlComando)
        {
            try
            {
                Conexao();
                OracleCommand cmd = new OracleCommand(sqlComando, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FinalizarConexao();
            }
        }
        public static int ExecutarComandoRetorno(string sqlComando)
        {
            try
            {
                Conexao();
                OracleCommand cmd = new OracleCommand(sqlComando, connection);
                int d = Convert.ToInt32(cmd.ExecuteScalar());
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FinalizarConexao();
            }
        }

        public static DataSet RetornarDataSet(string sqlComando)
        {
            try
            {
                Conexao();
                ds = new DataSet();
                cmd = new OracleCommand(sqlComando, connection);
                da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
        public string PesquisarProduto(int codProd)
        {
            SQL = "SELECT NOME FROM FELIPE.PRODUTOS WHERE PRODUTOS.NOME = :NomePROD";
            cmd = new OracleCommand(SQL, connection);
            cmd.CommandText = SQL;

            return cmd.ExecuteScalar().ToString();
        }

        public OracleDataReader RetornarDataReader(string sqlComando)
        {
            try
            {
                cmd = new OracleCommand(sqlComando, ConexaoBanco());
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RetornarDataTable(string sqlComando)
        {
            try
            {
                DataTable dt = new DataTable();
                cmd = new OracleCommand(sqlComando, connection);
                da = new OracleDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        }*/
    }

}