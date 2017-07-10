using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Data;

public partial class Contato : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    private OracleCommand cmd;
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        ConnectionClass.Conexao();
        cmd = new OracleCommand("insert_mensagem", ConnectionClass.connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("p_nome", OracleDbType.Varchar2).Value = txtMensagem.Text;
        cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = txtNome.Text ;
        cmd.Parameters.Add("p_mensagem", OracleDbType.Varchar2).Value =txtEmail.Text;
        cmd.ExecuteNonQuery();
    }
}