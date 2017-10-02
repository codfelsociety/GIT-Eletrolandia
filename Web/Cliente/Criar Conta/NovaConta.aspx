<%@ Page Title="Nova Conta" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="NovaConta.aspx.cs" Inherits="Cliente_Criar_Conta_NovaConta" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="Server">
    <link href="NovaConta.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Conteudo" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="cont" class="container pt-2 pb-2 mt-3">
        <div class="row">
            <div class="col mb-2">
                <h4 style="text-align:center">Cadastro de alguém</h4>
            </div>
        </div>
        <div style="margin:auto; max-width: 600px;" class="container-fluid">
            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Nome" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtNome" CssClass="form-control form-control-sm" Style="width:100%;" runat="server" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="CPF" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtCPF" CssClass="form-control form-control-sm" MaxLength="11" runat="server" Style="width: 100%" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Usuário" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtUsuario" CssClass="form-control form-control-sm" runat="server" Style="width: 100%" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Email" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtEmail" CssClass="form-control form-control-sm" runat="server" Style="width: 100%" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Senha" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtSenha1" CssClass="form-control form-control-sm" runat="server" Style="width: 100%" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Confirmar" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtSenha2" CssClass="form-control form-control-sm" runat="server" Style="width: 100%" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="CEP" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtCEP" CssClass="form-control form-control-sm" MaxLength="8" runat="server" placeholder="00000-000" Style="width: 100%" AutoPostBack="true" OnTextChanged="txtCEP_TextChanged" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Estado" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtEstado" CssClass="form-control form-control-sm" MaxLength="2"  placeholder="Ex: SP, RS, PR, SC..." runat="server" Style="width: 100%" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Cidade" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control form-control-sm" Style="width: 100%" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Bairro" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtBairro" CssClass="form-control form-control-sm" runat="server" Style="width: 100%" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Rua" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtRua" CssClass="form-control form-control-sm" runat="server" Style="width: 100%" />
                </div>
                <div class="col-1">
                    <asp:Label Text="nº" runat="server" Style="float: right;" />
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtNumero" CssClass="form-control form-control-sm" MaxLength="4" runat="server" Style="width: 100%" />
                </div>
            </div>

              <div class="row mb-1">
                <div class="col-2">
                    <asp:Label Text="Complemento" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtComplemento" CssClass="form-control form-control-sm" runat="server" Style="width: 100%" />
                </div>
            </div>

            <div class="row mb-1">
                <div class="col-2" >&nbsp;</div>
                <div class="col">
                    <asp:Button ID="btnCadastrar" style="width:100%;" CssClass="btn bg-success" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

