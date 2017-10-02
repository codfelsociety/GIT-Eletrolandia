using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCC.Model
{
    public class AcessoUsuario
    {
        private int id;
        private string descricao;

        public int Id { get { return id; } set { id = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }

        public static List<AcessoUsuario> Listar()
        {
            List<AcessoUsuario> acesso = new List<AcessoUsuario>();
            foreach (DataRow r in Consulta.Tudo("acesso").Rows)
            {
                AcessoUsuario acessoUsuario = new AcessoUsuario();
                acessoUsuario.Id = Convert.ToInt32(r["id"]);
                acessoUsuario.Descricao = Convert.ToString(r["descricao"]);
                acesso.Add(acessoUsuario);
            }
            return acesso;
        }
    }
}
