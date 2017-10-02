using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cliente_Criar_Conta_NovaConta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        Endereco endereco = new Endereco();
        endereco.Cep = txtCEP.Text;
        endereco.Numero = txtNumero.Text;
        endereco.Complemento = txtComplemento.Text;

        Cliente cliente = new Cliente();
        cliente.Nome = txtNome.Text;
        cliente.Cpf = txtCPF.Text;
        cliente.Email = txtEmail.Text;
        cliente.Usuario = txtUsuario.Text;
        cliente.Senha = txtSenha1.Text;
        cliente.IdEndereco = endereco.Adicionar();
        cliente.Adicionar();
    }

    protected void txtCEP_TextChanged(object sender, EventArgs e)
    {
        TextBox cep = (TextBox)sender;
        if(cep.Text.Length == 8)
        {
            Endereco endereco = Endereco.PesquisarCEP(cep.Text);
            txtEstado.Text = endereco.Estado;
            txtCidade.Text = endereco.Cidade;
            txtBairro.Text = endereco.Bairro;
            txtRua.Text = endereco.Rua;
        }
    }
}