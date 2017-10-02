using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cliente_Login_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogar_Click(object sender, EventArgs e)
    {
        Cliente cliente = new Cliente();
        cliente.Usuario = txtUsuario.Text;
        cliente.Senha = txtSenha.Text;
        if(cliente.Logar() != null)
        {
            FormsAuthentication.RedirectFromLoginPage(cliente.Usuario, true);
        }
        else
        {
            lblErro.Text = "Usuário ou Senha incorretos;";
        }
    }
}