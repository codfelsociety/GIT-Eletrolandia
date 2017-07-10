<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Contato.aspx.cs" Inherits="Contato" EnableEventValidation="False" ValidateRequest="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">

        <div class="row" style="background-color: rgb(240, 240, 240); padding: 15px; margin-top: 15px;">

            <div class="col-12 col-sm-6" style="margin-bottom: 10px;">
                <h2>Envie-nos uma mensagem</h2>

                <div class=" form-line">
                    <div class="form-group">
                        <label for="exampleInputUsername">Nome</label>&nbsp;
                        <asp:RequiredFieldValidator ID="rqNome" runat="server" ErrorMessage="Preencha o campo nome." ControlToValidate="txtNome" ForeColor="#CC0000">•</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="reNome" runat="server" ControlToValidate="txtNome" ErrorMessage="O nome deve conter apenas letras" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z'.\s]{1,50}">•</asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="txtNome" placeholder="Insira o seu nome" />
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail">E-mail</label>&nbsp;
                        <asp:RequiredFieldValidator ID="rqEmail" runat="server" ErrorMessage="Preencha o campo de email" ControlToValidate="txtEmail" ForeColor="#CC0000">•</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="E-mail inválido" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">•</asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" type="email" class="form-control" ID="txtEmail" placeholder="Digite aqui o email" TextMode="Email" />
                    </div>
                    <div class="form-group">
                        <label for="description">Mensagem&nbsp;&nbsp;&nbsp; </label>
                        <asp:RequiredFieldValidator ID="rqMensagem" runat="server" ControlToValidate="txtMensagem" ErrorMessage="Prencha a mensagem" ForeColor="#CC0000">•</asp:RequiredFieldValidator>
                        &nbsp;
                        <asp:TextBox runat="server" class="form-control" ID="txtMensagem" placeholder="Digite aqui a mensagem que deseja enviar" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" />

                <asp:Button runat="server"  class="btn btn-default" Style="width: 100%" Text="Enviar" ID="btnEnviar" OnClick="btnEnviar_Click" ValidateRequestMode="Enabled"></asp:Button>
                <br />
            </div>
            <div class="col-12 col-sm-6" style="padding: 0px 13px;">
                <div style="width: 100%; padding: 10px;">
                    <h3>Informações:</h3>
                    <b>Telefone 1: </b>&nbsp; 0800 788 1240<br />
                    <b>Telefone 2: </b>&nbsp; 0800 847 2515<br />
                    <b>Email:</b> &nbsp; eletrolandia@thestore.com<br />
                    <b>Endereço:</b> &nbsp;  Rua Avenida das Estradas - nº 042 Jd. Garden Barueri-SP<br />
                    <div id="map" style="width: 100%; height: 200px; margin-top: 15px"></div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function initMap() {
            var uluru = { lat: -23.51118652, lng: -46.86821759 };
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 14,
                center: uluru,
                mapTypeId: 'satellite'

            });
            var marker = new google.maps.Marker({
                position: uluru,
                map: map
            });
        }
    </script>
    <script async defer
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBY5ga-eisjKHydzUBXsPB1XnEiRfOyIcU&callback=initMap">
    </script>
</asp:Content>

