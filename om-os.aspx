<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="om-os.aspx.cs" Inherits="om_os" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/page.min.css" rel="stylesheet" />
    <link rel="import" href="bower_components/breadcrumb/breadcrumb.html" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <!-- get breadcrumb -->
        <bread-crumb type="first"><a href="/hjem">Hjem</a></bread-crumb><bread-crumb type="last"><a href="/om-os">Om Os</a></bread-crumb>
    </div>
    <div class="content">
        <aside>
            <!-- get page name -->
            <h2>Page Name</h2>
            <hr />
            <ul>
                <!-- get subpages -->
                <li><a href="#">subpage</a></li>
                <li><a href="#">subpage</a></li>
                <li><a href="#">subpage</a></li>
            </ul>
            <a class="buy" href="/how-to-buy">How To Buy</a>
        </aside>
        <div class="page">
            <div class="top"></div>
            <!-- get content -->
            content
        </div>
    </div>
</asp:Content>

