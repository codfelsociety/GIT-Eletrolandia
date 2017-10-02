using System.Data;
using DAO;
using Oracle.DataAccess.Client;

namespace BLL
{
    public class Frete
    {
        private string SQL;
        private OracleCommand cmd;
        private int _codFrete;
        private double _peso;
        private double _altura;
        private double _comprimento;
        private double _largura;
        private int _isFree;
        private int _isFragile;

        public int CodFrete { get { return _codFrete; }set { _codFrete = value; } }
        public double Peso { get { return _peso; }set { _peso = value; } }
        public double Altura { get { return _altura; }set { _altura = value; } }
        public double Comprimento { get { return _comprimento; }set { _comprimento = value; } }
        public double Largura { get { return _largura; }set { _largura = value; } }
        public int IsFree { get { return _isFree; }set { _isFree = value; } }
        public int IsFragile { get { return _isFragile; }set { _isFragile = value; } }

        public void Cadastrar()
        {
            SQL = $"INSERT INTO frete VALUES({CodFrete}, {Peso}, {Altura}, {Largura}, {Comprimento}, {IsFree},{IsFragile})";
            ClasseConexao con = new ClasseConexao();
            con.ExecutarComando(SQL);
        }
        public int IDFrete()
        {
            SQL = "SELECT seq_frete.NEXTVAL FROM DUAL";
            return ClasseConexao.ExecutarComandoRetorno(SQL);
        }
        public void Alterar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("UpdateFrete", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_frete", "NUMBER").Value = CodFrete;
            cmd.Parameters.Add("p_peso", "NUMBER").Value = Peso;
            cmd.Parameters.Add("p_altura", "NUMBER").Value = Altura;
            cmd.Parameters.Add("p_largura", "NUMBER").Value = Largura;
            cmd.Parameters.Add("p_comprimento", "NUMBER").Value = Comprimento;
            cmd.Parameters.Add("p_isfree", "NUMBER").Value = IsFree;
            cmd.Parameters.Add("p_fragil", "NUMBER").Value = IsFragile;
            cmd.ExecuteNonQuery();
        }
    }
}
