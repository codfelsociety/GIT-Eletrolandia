using System.Data;
using DAO;

namespace BLL
{
    public class Marca
    {
        private static string SQL;
        public static DataView Load()
        {
            SQL = "SELECT COD_MARCA, DESCRICAO FROM MARCA ORDER BY  COD_MARCA";
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
