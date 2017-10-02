using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCC.Model
{
    public class StatusUsuario
    {
        private int id;
        private string descricao;


        public int Id { get { return id; } set { id = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }

        public static List<StatusUsuario> Listar()
        {
            List<StatusUsuario> status = new List<StatusUsuario>();
            foreach (DataRow r in Consulta.Tudo("statusUsuario").Rows)
            {
                StatusUsuario statusUsuario = new StatusUsuario();
                statusUsuario.Id = Convert.ToInt32(r["id"]);
                statusUsuario.Descricao = Convert.ToString(r["descricao"]);
                status.Add(statusUsuario);
            }
            return status;
        }
    }
}
