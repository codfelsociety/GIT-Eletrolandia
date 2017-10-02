<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Confirmacao.aspx.cs" Inherits="Confirmacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container p-2">
        <div class="row pt-2" style="background-color:#14B3E9">
            <div class="col-12">
                <h3 style="color:#F7F8FC; font-family:'Calibri Light'">Carrinho</h3>
            </div>
        </div>
        <div class="row" style="background-color:white; ">
            <div class="col-12">
                <div class="row" style="height:400px;">
                    <div class="col-6">
                        <asp:GridView ID="GridView1" runat="server" style="width:100%; height:200px;margin-top:15px;" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"></asp:GridView>
                    </div>
                    <div class="col-6">
                        
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-md-6">
                        ...
                    </div>
                    <div class="col-sm-12 col-md-6">
                        <asp:Button runat="server" ID="btnConfirmar" style="width:50%; border:none; height:50px; background-color:#7AD49A;border-radius:10px; font-size:30px; font-family:'Calibri Light'; float:right; text-shadow:1px 1px 1px #000;position:relative; color:White; margin-bottom:15px;" Text="Avançar" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

