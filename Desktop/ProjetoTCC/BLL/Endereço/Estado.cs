using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BLL
{
    public class Estado
    {
        private int _id;
        private int _nome;

        public int ID { get => _id; set => _id = value; }
        public int Nome { get => _nome; set => _nome = value; }


        public static DataTable Carregar()
        {
            ClasseConexao.Conexao();
            SQL = "SELECT ID, UF AS NOME  FROM ESTADO";
            return ClasseConexao.RetornarDataTable(SQL);
        }


        static string SQL;
    }
}
