﻿using System.Data;
using DAO;

namespace BLL
{
    public class Categoria
    {
        private static string SQL;
        public static DataView Load()
        {
            SQL = "SELECT * FROM categoria_produto";
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
