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
                <li><a href="/produkter.aspx?iq-software=0">IQ Software</a></li>
                <li id="tilbehor" runat="server"><a href="/produkter.aspx?tilbehør=0">tilbehør</a></li>
                <li><a href="/produkter.aspx?produkt-sammenligner=0">Produkt sammenligner</a></li>
            </ul>
            <a class="buy" href="/how-to-buy.aspx">How To Buy</a>
        </aside>
        <div id="S" class="page" runat="server">
            <asp:Literal ID="litProductDescription" runat="server" />
            <div class="top">
                <asp:Literal ID="litTop" runat="server" />
            </div>
            <div id="S1" class="produkter" runat="server">
                <asp:Literal ID="litContent" runat="server" />
            </div>
        </div>
    </div>
    <script>
        var infos = document.querySelectorAll('.top p');

        if (infos !== null) {
            for (var i = 0; i < infos.length; i++) {
                infos[i].addEventListener('click', function () {
                    selectProductInfo(this, infos);
                });
            }
        }
        function selectProductInfo(e, infos) {
            var prodContents = document.querySelectorAll('.prodContent div'),
                p = 0;

            for (var i = 0; i < infos.length; i++) {
                if (e === infos[i]) {
                    p = i;
                }
                var Class = prodContents[i].getAttribute('class').match(/^\w+/);
                prodContents[i].setAttribute('class', Class + ' hidden');

                infos[i].removeAttribute('class');
            }
            var selfClass = prodContents[p].getAttribute('class').match(/^\w+/);
            prodContents[p].setAttribute('class', selfClass);
            e.setAttribute('class', 'selected');
        }
    </script>
</asp:Content>

