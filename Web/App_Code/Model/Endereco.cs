using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class Endereco
{
    private int id;
    private string cep;
    private string estado;
    private string cidade;
    private string bairro;
    private string rua;
    private string numero;
    private string complemento;


    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }
    public string Cep
    {
        get
        {
            return cep;
        }

        set
        {
            cep = value;
        }
    }
    public string Estado
    {
        get
        {
            return estado;
        }

        set
        {
            estado = value;
        }
    }
    public string Cidade
    {
        get
        {
            return cidade;
        }

        set
        {
            cidade = value;
        }
    }
    public string Bairro
    {
        get
        {
            return bairro;
        }

        set
        {
            bairro = value;
        }
    }
    public string Rua
    {
        get
        {
            return rua;
        }

        set
        {
            rua = value;
        }
    }
    public string Numero
    {
        get
        {
            return numero;
        }

        set
        {
            numero = value;
        }
    }
    public string Complemento
    {
        get
        {
            return complemento;
        }

        set
        {
            complemento = value;
        }
    }



    public static Endereco PesquisarCEP(string cep)
    {
        DataRow pesquisa = Base.Consulta.GetView("SEARCH_CEP", "CEP", cep).Rows[0];
        Endereco endereco = new Endereco();
        endereco.Estado = pesquisa["ESTADO"].ToString();
        endereco.Rua = pesquisa["RUA"].ToString();
        endereco.Cidade = pesquisa["CIDADE"].ToString();
        endereco.Bairro = pesquisa["BAIRRO"].ToString();
        return endereco;
    }
    public int Adicionar()
    {
        Base.Connection.Open();
        OracleCommand cmd = new OracleCommand("ADICIONARENDEREÇO", Base.Connection.connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("p_id", "NUMBER").Value = Id = Base.Consulta.NextID("ENDERECO");
        cmd.Parameters.Add("p_tipo", "NUMBER").Value = 1;
        cmd.Parameters.Add("p_cep", "VARCHAR2").Value = Cep;
        cmd.Parameters.Add("p_numero", "VARCHAR2").Value = Numero;
        cmd.Parameters.Add("p_complemento", "VARCHAR2").Value = Complemento;
        cmd.ExecuteNonQuery();
        return Id;
    }
}