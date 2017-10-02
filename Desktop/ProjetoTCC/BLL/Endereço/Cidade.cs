using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BLL
{
    public class Cidade
    {
        private int _id;
        private string nome;
        private int _estado;

        public int Id { get { return _id; }set { _id = value; } }
        public string Nome { get { return nome; }set { nome = value; } }
        public int Estado { get { return _estado; }set { _estado = value; } }

        public static DataTable Carregar(int estado)
        {
            ClasseConexao.Conexao();
            SQL = $"SELECT ID, NOME FROM CIDADE WHERE ESTADO ={estado}  ORDER BY NOME";
            return ClasseConexao.RetornarDataTable(SQL);
        }

        static string SQL;
    }
}
