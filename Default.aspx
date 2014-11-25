<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/default.min.css" rel="stylesheet" />
    <link rel="import" href="slider/index.html">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- get images -->
    <slider-component>
        <asp:literal ID="litSlider" runat="server" />
    </slider-component>
    <div class="first">
        <div class="vicon">
            <h3>Get To Know Vicon</h3>
            <p>An industry-leading provider of complete, IP-based security solutions for nearly 50 years.</p>
            <a href="http://www.vicon-security.com/" target="_blank">Læs Mere</a>
        </div>
        <div class="productSelector">
            <h3>Product Selector Tool</h3>
            <p>Allow us to assist you in finding the perfect IQeye camera for any application.</p>
            <!-- get options -->
            <div>
                <select>
                    <option>Kamera Type</option>
                </select>
                <select>
                    <option>Opløsning</option>
                </select>
                <a href="/?">Sammenlign</a>
            </div>
        </div>
    </div>
    <div class="secound">
        <div class="advantage">
            <div class="buttons">
                <a href="http://www.iqeye.com/resources/iqadvantages"><img width="111" height="27" src="img/iqadvantages.png" alt="Iq Advantages" /></a><a href="/nyheder">Nyheder</a>
            </div>
            <p>Home of IQeye H.264 and MJPEG HD Megapixel IP cameras. Leading the high-resolution and network camera industry since 1998, we offer complete surveillance camera systems, including day/night, vandal-resistant, and weatherproof IP cameras.</p>
        </div>
        <div class="resources">
            <a href="http://www.iqeye.com/sites/all/themes/iqinvision/images/learn-more-gray.png">Learn More</a>
        </div>
    </div>
</asp:Content>

