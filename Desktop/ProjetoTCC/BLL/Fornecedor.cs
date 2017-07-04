using System.Data;
using DAO;
using Oracle.DataAccess.Client;

namespace BLL
{
    public class Fornecedor
    {
        private int _codFornecedor;
        private int _codEndereco;
        private int _codContato;
        private string _nome;
        private string _cnpj;
        private string _insEstadual;
        private string _descricao;

        public int CodFornecedor { get => _codFornecedor; set => _codFornecedor = value; }
        public int CodEndereco { get => _codEndereco; set => _codEndereco = value; }
        public int CodContato { get => _codContato; set => _codContato = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cnpj { get => _cnpj; set => _cnpj = value; }
        public string InsEstadual { get => _insEstadual; set => _insEstadual = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }

        private static string SQL;
        private static OracleCommand cmd;
        public static DataView Load()
        {
            SQL = "SELECT COD_FORNECEDOR, NOME FROM fornecedor";
            DataView dv = ClasseConexao.RetornarDataTable(SQL).DefaultView;

            return dv;
        }
        public void Cadastrar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_fornecedores", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_endereco", OracleDbType.Int32).Value = CodEndereco;
            cmd.Parameters.Add("p_cod_contato", OracleDbType.Int32).Value = CodContato;
            cmd.Parameters.Add("p_nome", OracleDbType.Varchar2).Value = Nome;
            cmd.Parameters.Add("p_cnpj", OracleDbType.Varchar2).Value = Cnpj;
            cmd.Parameters.Add("p_estadual", OracleDbType.Varchar2).Value = InsEstadual;
            cmd.Parameters.Add("p_descricao", OracleDbType.Varchar2).Value = Descricao;
            cmd.ExecuteNonQuery();
        }
        public void Alterar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("update_fornecedores", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_fornecedor", OracleDbType.Int32).Value = CodFornecedor;
            cmd.Parameters.Add("p_cod_endereco", OracleDbType.Int32).Value = CodEndereco;
            cmd.Parameters.Add("p_cod_contato", OracleDbType.Int32).Value = CodContato;
            cmd.Parameters.Add("p_nome", OracleDbType.Varchar2).Value = Nome;
            cmd.Parameters.Add("p_cnpj", OracleDbType.Varchar2).Value = Cnpj;
            cmd.Parameters.Add("p_estadual", OracleDbType.Varchar2).Value = InsEstadual;
            cmd.Parameters.Add("p_descricao", OracleDbType.Varchar2).Value = Descricao;
            cmd.ExecuteNonQuery();
        }
        public void Apagar()
        {

        }
    }
}
