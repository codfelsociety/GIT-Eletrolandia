using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Entrega
    {
        private static string SQL;
        private static OracleCommand cmd;

        private int _idEntrega;
        private int _idEndereco;
        private int _idContato;
        private string _nome;

        public int IdEntrega { get { return _idEntrega; } set { _idEntrega = value; } }
        public int IdEndereco { get { return _idEndereco; } set { _idEndereco = value; } }
        public int IdContato { get { return _idContato; } set { _idContato = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
    }
}
