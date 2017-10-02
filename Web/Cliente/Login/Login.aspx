<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Cliente_Login_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:aliceblue" class="container pt-2 pb-2 mt-3">
        <div class="row">
            <div class="col mb-2">
                <h4 style="text-align:center">Login</h4>
            </div>
        </div>
        <div style="margin:auto; max-width: 600px;" class="container-fluid">
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
                    <asp:Label Text="Senha" runat="server" Style="float: right;" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtSenha" CssClass="form-control form-control-sm" runat="server" Style="width: 100%" />
                </div>
            </div>
            <div class="row mb-1">
                <div class="col-2" >&nbsp;</div>
                <div class="col">
                    <asp:Button ID="btnLogar" style="width:100%;" CssClass="btn bg-success" runat="server" Text="Login" OnClick="btnLogar_Click" />
                </div>
            </div>
            <div class="row mb-1">
                <div class="col">
                    <asp:Label  style="text-align:center; margin:auto;color:red" runat="server" ID="lblErro" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

