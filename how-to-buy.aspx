<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="how-to-buy.aspx.cs" Inherits="how_to_buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/page.min.css" rel="stylesheet" />
    <link rel="import" href="/bower_components/breadcrumb/breadcrumb.html" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <bread-crumb type="first"><a href="/hjem">Hjem</a></bread-crumb><bread-crumb type="last"><a href="/how-to-buy">How to buy</a></bread-crumb>
    </div>
    <div class="content">
        <aside>
            <h2>How To Buy</h2>
            <hr />
            <ul>
            </ul>

        </aside>
        <div class="page">
            <div class="top"></div>
            <div class="howto">
                <h2>How to buy</h2>
                <p>
                    Thank you for your interest in IQinVision camera products, software and service.
Our sales representatives, distribution and premier partners are ready to answer your questions. Please select an option below for immediate service.
                </p>

                <h2>Contact a sales proffessional</h2>
                <div class="contact">
                    <div class="field1">
                        <asp:TextBox ID="txtName" placeholder="navn *" runat="server" />
                        <asp:TextBox ID="txtEmail" placeholder="email *" runat="server" />
                        <asp:TextBox ID="txtSubject" placeholder="emne *" runat="server" />
                        <asp:TextBox ID="txtPhone" TextMode="Number" placeholder="telefon" runat="server" />
                        <asp:TextBox ID="txtCompany" placeholder="firma" runat="server" />
                    </div>
                    <div class="field2">
                        <asp:TextBox ID="txtDescription" placeholder="beskrivelse *" TextMode="MultiLine" runat="server" />
                        <asp:TextBox ID="txtComments" placeholder="andre kommaterer" TextMode="MultiLine" runat="server" />
                        <asp:Button ID="btnSend" Text="Send" OnClick="btnSend_Click" OnClientClick="checkFields()" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function checkFields() {
            var inputs = document.querySelectorAll('.field1 input'),
                textareas = document.querySelectorAll('.field2 textarea'),
                t = false;

            console.log(inputs[0].value);

            if (inputs[0].value === "") {
                t = true;
                inputs[0].setAttribute('class', 'error');
            }
            else {
                inputs[0].removeAttribute('class');
            }
            if (inputs[1].value === "") {
                t = true;
                inputs[1].setAttribute('class', 'error');
            }
            else {
                inputs[1].removeAttribute('class');
            }
            if (inputs[2].value === "") {
                t = true;
                inputs[2].setAttribute('class', 'error');
            }
            else {
                inputs[2].removeAttribute('class');
            }
            if (textareas[0].value === "") {
                t = true;
                textareas[0].setAttribute('class', 'error');
            }
            else {
                textareas[0].removeAttribute('class');
            }
            if (t) {
                event.preventDefault();
            }

        }

    </script>
</asp:Content>
