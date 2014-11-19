<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="bower_components/platform/platform.js"></script>
    <link rel="import" href="bower_components/polymer/polymer.html">
    <link rel="import" href="slider/index.html">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <slider-component>
        <img src="/slider/images/alliance-mini-ii.jpg" alt="" />
        <img src="/slider/images/alliance-pro.jpg" alt="" />
    </slider-component>
    <div class="first">
        <div class="vicon">
            <h3>Get To Know Vicon</h3>
            <p>An industry-leading provider of complete, IP-based security solutions for nearly 50 years.</p>
            <a href="http://www.vicon-security.com/" target="_blank"><img src="img/learn-more.jpg" width="114" height="27" alt="Learn More"></a>
        </div>
        <div class="productSelector">
            <p>Allow us to assist you in finding the perfect IQeye camera for any application.</p>
            <div>
                <select>
                    <option>Kamera Type</option>
                </select>
                <select>
                    <option>Opløsning</option>
                </select>
                <asp:ImageButton ImageUrl="/img/compare.jpg" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

