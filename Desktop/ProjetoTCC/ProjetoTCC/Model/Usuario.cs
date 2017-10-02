using System;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Data;

namespace ProjetoTCC.Model
{
    public class Usuario
    {
        private int id;
        private int acesso;
        private int sexo;
        private string nome;
        private string sobrenome;
        private string username;
        private string email;
        private string senha;
        private string dataCadastro;
        private byte[] foto;
        private int status;

        public int Id { get { return id; } set { id = value; } }
        public int Acesso { get { return acesso; } set { acesso = value; } }
        public int Sexo { get { return sexo; } set { sexo = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string Sobrenome { get { return sobrenome; } set { sobrenome = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Senha { get { return senha; } set { senha = value; } }
        public string DataCadastro { get { return dataCadastro; } set { dataCadastro = value; } }
        public byte[] Foto { get { return foto; } set { foto = value; } }
        public int Status { get { return status; } set { status = value; } }

        public Usuario()
        {
           
        }
        public Usuario(int cod)
        {
            DataRow dr = Consulta.Tudo("usuario", "id", cod.ToString()).Rows[0];
            Id = Convert.ToInt32(dr["id"]);
            Sexo = Convert.ToInt32(dr["sexo"]);
            Nome = dr["nome"].ToString();
            Sobrenome = dr["sobrenome"].ToString();
            Username = dr["username"].ToString();
            Email = dr["email"].ToString();
            Senha = dr["senha"].ToString();
            DataCadastro = dr["dataCadastro"].ToString();
            Acesso = Convert.ToInt32(dr["acesso"]);
            Status = Convert.ToInt32(dr["status"]);
            Foto = dr["foto"] as byte[];
        }

        public void Adicionar()
        {
            Procedure.Execute("adicionarUsuario", this);
        }
        public void Alterar()
        {
            Procedure.Execute("adicionarUsuario", this);
        }

        public static int NextId()
        {
            return Consulta.ShowNextId("Usuario");
        }

    }
}
