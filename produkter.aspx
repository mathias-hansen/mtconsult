<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="produkter.aspx.cs" Inherits="produkter" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/produkter.min.css" rel="stylesheet" />
    <link rel="import" href="/bower_components/breadcrumb/breadcrumb.html" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <asp:Literal ID="litBreadcrumb" runat="server" />
    </div>
    <div class="content">
        <aside>
            <h2>Produkter</h2>
            <hr />
            <ul>
                <li>
                    <a href="/produkter.aspx">Standard Kameraer</a>
                    <ul>
                        <asp:Literal ID="litStd" runat="server" />
                    </ul>
                </li>
                <li>
                    <a href="/produkter.aspx">Dome Kameraer</a>
                    <ul>
                        <asp:Literal ID="litDome" runat="server" />
                    </ul>
                </li>
                <li><a href="/produkter.aspx/iq-software">IQ Software</a></li>
                <li><a href="/produkter.aspx/tilbehør">tilbehør</a></li>
                <li><a href="/produkter.aspx/produkt-sammenligner">Produkt sammenligner</a></li>
            </ul>
            <a class="buy" href="/how-to-buy.aspx">How To Buy</a>
        </aside>
        <div class="page">
            <div class="top"></div>
            <div class="produkter">
                <asp:Literal ID="litContent" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

