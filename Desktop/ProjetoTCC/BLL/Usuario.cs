using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Oracle.DataAccess.Client;
using System.Data;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;

namespace BLL
{
    public class Usuario
    {
        private static string SQL;
        private static OracleCommand cmd;
        private int _codUsuario;
        private string _nome;
        private string _sobrenome;
        private int _acesso;
        private string _dataCadastro;
        private string _senha;
        private string _username;
        private string _email;
        private int _sexo;
        private DataTable _picture;


        public int CodUsuario { get => _codUsuario; set => _codUsuario = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Sobrenome { get => _sobrenome; set => _sobrenome = value; }
        public int Acesso { get => _acesso; set => _acesso = value; }
        public string DataCadastro { get => _dataCadastro; set => _dataCadastro = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public string Email { get => _email; set => _email = value; }
        public int Sexo { get => _sexo; set => _sexo = value; }
        public string Username { get => _username; set => _username = value; }
        public DataTable Picture { get => _picture; set => _picture = value; }

        public void Cadastrar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("insert_usuario", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_usuario", OracleDbType.Int32).Value = CodUsuario;
            cmd.Parameters.Add("p_cod_acesso", OracleDbType.Int32).Value = Acesso;
            cmd.Parameters.Add("p_cod_sexo", OracleDbType.Int32).Value = Sexo;
            cmd.Parameters.Add("p_nome", OracleDbType.Varchar2).Value = Nome;
            cmd.Parameters.Add("p_sobrenome", OracleDbType.Varchar2).Value = Sobrenome;
            cmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = Username;
            cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = Email;
            cmd.Parameters.Add("p_senha", OracleDbType.Varchar2).Value = Senha;
            cmd.Parameters.Add("p_datacadastro", OracleDbType.Varchar2).Value = DataCadastro;
            PngBitmapEncoder p = new PngBitmapEncoder();
            byte[] blob = ImageSourceToBytes(p, Picture.Rows[0][1] as ImageSource);
            cmd.Parameters.Add("p_picture", OracleDbType.Blob).Value = blob;

            cmd.ExecuteNonQuery();
        }

        public void Alterar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("update_usuario", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_usuario", OracleDbType.Int32).Value = CodUsuario;
            cmd.Parameters.Add("p_cod_acesso", OracleDbType.Int32).Value = Acesso;
            cmd.Parameters.Add("p_cod_sexo", OracleDbType.Int32).Value = Sexo;
            cmd.Parameters.Add("p_nome", OracleDbType.Varchar2).Value = Nome;
            cmd.Parameters.Add("p_sobrenome", OracleDbType.Varchar2).Value = Sobrenome;
            cmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = Username;
            cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = Email;
            cmd.Parameters.Add("p_senha", OracleDbType.Varchar2).Value = Senha;
            PngBitmapEncoder p = new PngBitmapEncoder();
            byte[] blob = ImageSourceToBytes(p, Picture.Rows[0][1] as ImageSource);
            cmd.Parameters.Add("p_picture", OracleDbType.Blob).Value = blob;
            cmd.ExecuteNonQuery();
        }

        public void Apagar()
        {
            ClasseConexao.Conexao();
            cmd = new OracleCommand("delete_usuario", ClasseConexao.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_usuario", OracleDbType.Int32).Value = CodUsuario;
            cmd.ExecuteNonQuery();
        }

        public static int PreverProxID()
        {
            SQL = "SELECT valor FROM max_seq WHERE cod_seq = 2";
            return Convert.ToInt32(ClasseConexao.RetornarDataTable(SQL).Rows[0][0]) + 1;
        }

        public int RetornarProxID()
        {
            SQL = "SELECT seq_usuario.NEXTVAL FROM DUAL";
            return Convert.ToInt32(ClasseConexao.RetornarDataTable(SQL).Rows[0][0]);
        }
        public byte[] ImageSourceToBytes(BitmapEncoder encoder, ImageSource imageSource)
        {
            byte[] bytes = null;
            var bitmapSource = imageSource as BitmapSource;

            if (bitmapSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    bytes = stream.ToArray();
                }
            }

            return bytes;
        }

        public static  DataTable RetornarUsuarioInterface()
        {
            SQL = @"SELECT us.cod_usuario as cod, ac.descricao as acesso, se.descricao as sexo, 
            us.nome || ' ' || us.sobrenome as nome, us.username, us.senha, us.email, us.datacadastro,
            us.picture FROM usuario us 
            JOIN acesso ac ON us.cod_acesso = ac.cod_acesso
            JOIN sexo   se ON us.cod_sexo   = se.cod_sexo";
            return ClasseConexao.RetornarDataTable(SQL);
        }

        public static DataTable RetornarUsuarioInfo(int cod)
        {
            SQL = $@"SELECT * FROM usuario WHERE cod_usuario = {cod}";
            return ClasseConexao.RetornarDataTable(SQL);
        }
    }
}
