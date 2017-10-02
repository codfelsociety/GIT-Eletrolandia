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
            Procedure usuario = new Procedure("adicionarUsuario");
            usuario.Add("p_id", OracleDbType.Int32, Id);
            usuario.Add("p_acesso", OracleDbType.Int32, Acesso);
            usuario.Add("p_sexo", OracleDbType.Int32, Sexo);
            usuario.Add("p_nome", OracleDbType.Varchar2, Nome);
            usuario.Add("p_sobrenome", OracleDbType.Varchar2, Sobrenome);
            usuario.Add("p_username", OracleDbType.Varchar2, Username);
            usuario.Add("p_email", OracleDbType.Varchar2, Email);
            usuario.Add("p_senha", OracleDbType.Varchar2, Senha);
            usuario.Add("p_dataCadastro", OracleDbType.Varchar2,DataCadastro);
            usuario.Add("p_foto", OracleDbType.Blob, Foto);
            usuario.Add("p_status", OracleDbType.Int32, Status);
            usuario.Execute();
        }
        public void Alterar()
        {
            Procedure usuario = new Procedure("editarUsuario");
            usuario.Add("p_id", OracleDbType.Int32, Id);
            usuario.Add("p_acesso", OracleDbType.Int32, Acesso);
            usuario.Add("p_sexo", OracleDbType.Int32, Sexo);
            usuario.Add("p_nome", OracleDbType.Varchar2, Nome);
            usuario.Add("p_sobrenome", OracleDbType.Varchar2, Sobrenome);
            usuario.Add("p_username", OracleDbType.Varchar2, Username);
            usuario.Add("p_email", OracleDbType.Varchar2, Email);
            usuario.Add("p_senha", OracleDbType.Varchar2, Senha);
            usuario.Add("p_foto", OracleDbType.Blob, Foto);
            usuario.Execute();
        }
        public static int NextId()
        {
            return Consulta.ShowNextId("Usuario");
        }
        public static DataTable Listar()
        {
            return Consulta.GetView("viewUsuarios");

        }
        public void Apagar()
        {
            Procedure usuario = new Procedure("apagarUsuario");
            usuario.Add("p_id", OracleDbType.Int32, Id);
            usuario.Execute();
        }

        public void MudarStatus()
        {
            Procedure usuario = new Procedure("mudarStatusUsuario");
            usuario.Add("p_id", OracleDbType.Int32, Id);
            usuario.Add("p_status", OracleDbType.Int32, Status);
            usuario.Execute();
        }
    }
}
