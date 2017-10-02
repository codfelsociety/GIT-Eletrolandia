using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Pagamento
    {
        private static string SQL;
        private static OracleCommand cmd;

        private int _idPagamento;
        private int _idVenda;
        private int _tipo;
        private decimal _valor;

        public int IdPagamento { get { return _idPagamento; } set { _idPagamento = value; }}
        public int IdVenda { get { return _idVenda; } set { _idVenda = value; }}
        public int Tipo { get { return _tipo; } set { _tipo = value; }}
        public decimal Valor { get { return _valor; } set { _valor = value; }}
    }
}
