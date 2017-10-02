using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ProjetoTCC.Model
{
    public class Connection
    {
        static string
        host = "localhost",
        port = "1521",
        user = "ADMINO",
        password = "123456",
        sid = "XE";
        static string strConexao = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port})))(CONNECT_DATA=(SID={sid})));User ID={user};Password={password}";
        public static OracleConnection connection = new OracleConnection(strConexao);
        public static void Open()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)connection.Open();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void Close()
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
    }

    public class Procedure
    {
        /// <summary>
        /// Converte o tipo comum type para um tipo aceito pelo Oracle especificamente 
        /// Utiliza a propriedade .Name do tipo e retorna o valor em OracleDbType.
        /// </summary>
        private static OracleDbType ConvertPrimitiveToDbType(Type type)
        {

            switch (type.Name)
            {
                case "Int16": return OracleDbType.Int16;
                case "Int32": return OracleDbType.Int32;
                case "Int64": return OracleDbType.Int64;
                case "String": return OracleDbType.Varchar2;
                case "byte[]": return OracleDbType.Blob;
                case "Byte[]": return OracleDbType.Blob;
                case "Char": return OracleDbType.Char;
                case "Image": return OracleDbType.Blob;
                case "Date": return OracleDbType.Date;
                default: break;
            }
            return OracleDbType.Object;

        }
        /// <summary>
        /// Método que recebe o nome da procedure e uma classe e tenta automaticamente criar e executar uma stored procedure.
        /// Método Disponível para Oracle.
        /// </summary>
        public static void Execute(string procedure, object classe)
        {
            try
            {
                //Abre a  conexão.
                Connection.Open();
                //Cria um novo comando com o nome da procedure na conexão aberta.
                OracleCommand cmd = new OracleCommand(procedure, Connection.connection);
                //Define o tipo do comando como sendo uma Stored Procedure.
                cmd.CommandType = CommandType.StoredProcedure;
                //Cria uma lista com as propriedades da classe inserida.
                IList<PropertyInfo> properties = new List<PropertyInfo>(classe.GetType().GetProperties());
                //Para cada propriedade existente na lista de propriedades
                foreach (PropertyInfo property in properties)
                {
                    //Pega o nome da propriedade e adiciona o p_ usado comumente no nome dos parâmetros das stored procedures.
                    string propName = ("P_" + property.Name).ToUpper();
                    //Recebe o tipo da propriedade.
                    Type propType = property.PropertyType;
                    //Recebe o valor da propriedade.
                    var propValue = property.GetValue(classe, null);
                    //Adiciona os parâmetros conseguidos.
                    cmd.Parameters.Add(propName, ConvertPrimitiveToDbType(propType)).Value = propValue;
                }
                //Executa o comando.
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro
                MessageBox.Show("Classe incompatível com Stored Procedure Espeficicada \nErro: " + ex.Message, "Atenção");
            }
        }
    }

    public class Consulta
    {

        /// <summary>
        /// Recebe um comando e retorna uma consulta em DataTable
        /// </summary>
        public static DataTable DataTable(string query)
        {
            return DataSet(query).Tables[0];
        }
        /// <summary>
        /// Retorna um datatable com todas as colunas de uma tabela inserida
        /// </summary>
        public static DataTable Tudo(string table)
        {
            return DataTable("SELECT * FROM " + table);
        }

        /// <summary>
        /// Retorna um datatable com todas as colunas de uma tabela inserida onde a coluna possui o valor especificado
        /// </summary>
        public static DataTable Tudo(string table, string column, string value)
        {
            return DataTable("SELECT * FROM " + table + " WHERE " + column + "='"+ value + "'");
        }
        /// <summary>
        /// Recebe um comando e retorna uma consulta em um DataSet
        /// </summary>
        public static DataSet DataSet(string query)
        {
            try
            {
                Connection.Open();
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand(query, Connection.connection);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Retorna em um DataTable a View do parâmetro.
        /// </summary>
        public static DataTable GetView(string view)
        {
            string SQL = $"SELECT * FROM {view}";
            return DataTable(SQL);
        }
        /// <summary>
        /// Retorna um DataTable da consulta da view onde existem a coluna 
        /// com o valor espeficicado.
        /// </summary>
        /// 
        public static DataTable GetView(string view, string column, string value)
        {
            string SQL = $"SELECT * FROM {view} WHERE {column} = {value}";
            return DataTable(SQL);
        }
        /// <summary>
        /// Retorna a contagem de linhas recebidas da consulta;
        /// </summary>
        public static int Count(string query)
        {
            try
            {
                Connection.Open();
                OracleCommand cmd = new OracleCommand(query, Connection.connection);
                int d = Convert.ToInt32(cmd.ExecuteScalar());
                Connection.Close();
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Retorna verdadeiro caso encontre linhas correspondentes à consulta;
        /// </summary>
        public static bool Check(string query)
        {
            if(Count(query) >= 1) return true; return false;
        }
        /// <summary>
        /// Retorna o próximo Id de uma sequência de uma tabela com o nome seq_&tablename.
        /// </summary>
        public static int NextId(string tablename)
        {
            string Query = "SELECT SEQ_" + tablename + ".NEXTVAL FROM DUAL";
            int result = Convert.ToInt32(DataTable(Query).Rows[0][0]);
            return result;
        }
        /// <summary>
        /// Apenas mostra o próximo Id de uma sequência de uma tabela, sem avançá-la.
        /// </summary>

        public static int ShowNextId(string tablename)
        {
            string Query = "SELECT last from max WHERE tablename ='" + tablename + "'" ;
            return Convert.ToInt32(DataTable(Query).Rows[0][0]) + 1;
        }
    }
}
