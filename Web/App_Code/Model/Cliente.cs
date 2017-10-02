using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data;


/// <summary>
/// Descrição resumida de Cliente
/// </summary>
public class Cliente
{
    private int id;
    private string nome;
    private string cpf;
    private string usuario;
    private string email;
    private string senha;
    private int idEndereco;

    public int Id { get { return id; } set { id = value; } }
    public string Nome { get { return nome; } set { nome = value; } }
    public string Cpf { get { return cpf; } set { cpf = value; } }
    public string Usuario { get { return usuario; } set { usuario = value; } }
    public string Email { get { return email; } set { email = value; } }
    public string Senha { get { return senha; } set { senha = value; } }
    public int IdEndereco { get { return idEndereco; } set { idEndereco = value; } }

    public void Adicionar()
    {
        Base.Procedure.Execute("ADICIONARCLIENTE", this);
    }

    public Cliente Logar()
    {
        string SQL = "SELECT * FROM CLIENTE WHERE USUARIO = '" + Usuario + "' AND SENHA='" + Senha + "'";
        DataTable cli = Base.Consulta.DataTable(SQL);
        if (cli.Rows.Count > 0)
        {
            DataRow pesquisa = cli.Rows[0];
            Cliente cliente = new Cliente();
            cliente.Nome = pesquisa["NOME"].ToString();
            cliente.Cpf = pesquisa["CPF"].ToString();
            cliente.Email = pesquisa["EMAIL"].ToString();
            return cliente;
        }
        return null;
    }
}