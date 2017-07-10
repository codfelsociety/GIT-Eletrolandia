<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="Pages_HomePage" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/test.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div id="carouselExampleIndicators" style="width: 100%; height: 200px;" data-interval="3000" class="carousel slide mt-2 mb-2" data-ride="carousel">
                <div class="carousel-inner" role="listbox">
                    <div class="carousel-item active">
                        <div class="d-block img-fluid" style="height: 200px; width: 100%; background-image: url(../Images/Wellcome.png); background-size: cover; background-position: center;"></div>
                        <div class="carousel-caption d-none d-md-block">
                            <h3>Bem vindo à eletrolândia</h3>
                            <p>Uma das melhores lojas de eletrônicos do bairro</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="d-block img-fluid" style="height: 200px; width: 100%; background-image: url(../Images/Something.png); background-size: cover; background-position: center;"></div>
                        <div class="carousel-caption d-none d-md-block">
                            <h3>Novos produtos Samsung</h3>
                            <p>Confira a nova linha.</p>
                        </div>
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
            <div style="background-color: rgb(240, 240, 240);" class="col-sm-3 pt-3 pr-2">
                <div style="width: 100%;">
                    <div  style="background-color: #2f436d; padding: 5px; text-align: center; color:white;"><h5>Categorias</h5></div>
                    <div class="cat" style="background-color: #c3c3c3; padding: 5px; margin-bottom: 5px; text-align: center;"><a href="#">Computadores</a></div>
                    <div class="cat" style="background-color: #c3c3c3; padding: 5px; margin-bottom: 5px; text-align: center"><a href="#">Periféricos</a></div>
                    <div class="cat" style="background-color: #c3c3c3; padding: 5px; margin-bottom: 5px; text-align: center"><a href="#">Hardware</a></div>
                    <div class="cat" style="background-color: #c3c3c3; padding: 5px; margin-bottom: 5px; text-align: center"><a href="#">Som & Imagem</a></div>
                    <div class="cat" style="background-color: #c3c3c3; padding: 5px; margin-bottom: 5px; text-align: center"><a href="#">Armazenamento</a></div>
                </div>
            </div>
            <div style="background-color: rgb(240, 240, 240);" class="col-sm-9 pt-3">
                <div class="card-deck">
                    <asp:ListView ID="listaProdutos" runat="server">
                        <ItemTemplate>
                            <div class="col-md-3">
                                <div class="card" style="margin: 5px -10px">
                                    <img id="imgFoto" class="card-img-top" style="width: 100%; display: block;" alt="Imagem Produto" onerror="this.src='http://xpenology.org/wp-content/themes/qaengine/img/default-thumbnail.jpg'" src='data:image/png;base64,<%# System.Convert.ToBase64String(ProcessImage(Eval("image")))%>' />
                                    <div class="card-block" style="padding: 10px;">
                                        <h6 class="card-title">
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("nome") %>'></asp:Label></h6>
                                        <h5>
                                            <asp:Label ID="lblpreco" runat="server"><span class="badge badge-default"> <%#string.Format("{0:R$#,###.##}", Eval("PRECO"))%></span></asp:Label></h5>
                                    </div>
                                    <div class="card-footer" style="padding: 10px;">
                                        <button type="button" class="btn btn-success">Comprar</button>
                                        &nbsp;
                                        <button type="button" class="btn btn-secondary">i</button>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

