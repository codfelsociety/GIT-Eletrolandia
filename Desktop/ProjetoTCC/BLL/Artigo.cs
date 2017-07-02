using System.Data;
using DAO;

namespace BLL
{
    public class Artigo
    {
        private static string SQL;
        public static DataView Load(int CodCategoria = 0)
        {
            if(CodCategoria != 0)
            SQL = "SELECT * FROM ARTIGO WHERE COD_CATEGORIA =" + CodCategoria ;
            else
            SQL = "SELECT * FROM ARTIGO";
            
            DataView dv = ClasseConexao.RetornarDataTable(SQL).DefaultView;
            return dv;
        }
        public void Cadastrar()
        {

        }
        public void Alterar()
        {

        }
        public void Apagar()
        {

        }
    }
}