<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="om-os.aspx.cs" Inherits="om_os" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/page.min.css" rel="stylesheet" />
    <link rel="import" href="bower_components/breadcrumb/breadcrumb.html" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <asp:Literal ID="litBreadcrumb" runat="server" />
    </div>
    <div class="content">
        <aside>
            <h2><asp:Literal ID="litPagename" runat="server" /></h2>
            <hr />
            <ul>
                <asp:Literal ID="litSubpages" runat="server" />
            </ul>
            <a class="buy" href="/how-to-buy">How To Buy</a>
        </aside>
        <div class="page">
            <div class="top"></div>
            <asp:Literal ID="litContent" runat="server" />
        </div>
    </div>
</asp:Content>

