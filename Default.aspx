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
            <h3>Lær Vicon at kænde</h3>
            <p>De bedste i branchen af it-baserede sikkerhedsløsninger i næsten 50 år.</p>
            <a href="http://www.vicon-security.com/" target="_blank">Læs Mere</a>
        </div>
        <div class="productSelector">
            <h3>Produkt sammenligner</h3>
            <p>Tillad os at hjælpe dig med at finde det perfekte IQeye kamera til enhver applikation.</p>
            <!-- get options -->
            <div>
                <select>
                    <option>Kamera Type</option>
                    <option value="010">Dome Indendørs</option>
                    <option value="011">Dome Indendørs/Udendørs</option>
                    <option value="001">Dome Udendørs</option>
                    <option value="110">Standard Indendørs</option>
                    <option value="111">Standard Indendørs/Udendørs</option>
                    <option value="101">Standard Udendørs</option>
                </select>
                <select>
                    <option>Opløsning</option>
                    <option value="720x480">0.3 MP / SD480p – (720 x 480)</option>
                    <option value="1280x720">1.0 MP / HD720p – (1280 x 720)</option>
                    <option value="1920x1080">2.0 MP / HD1080p – (1920 x 1080)</option>
                    <option value="2048x1536">3.1 MP – (2048 x 1536)</option>
                    <option value="2560x1440">3.6 MP – (2560 x 1440)</option>
                    <option value="2560x1920">5.0 MP – (2560 x 1920)</option>
                    <option value="4000x3000">12MP/4K – (4000 x 3000)</option>
                </select>
                <a href="/produkter.aspx/produkt-sammenligner">Sammenlign</a>
            </div>
        </div>
    </div>
    <div class="secound">
        <div class="advantage">
            <div class="buttons">
                <a href="http://www.iqeye.com/resources/iqadvantages">
                    <img width="111" height="27" src="img/iqadvantages.png" alt="Iq Advantages" /></a><a href="/nyheder.aspx">Nyheder</a>
            </div>
            <p>Home of IQeye H.264 and MJPEG HD Megapixel IP cameras. Leading the high-resolution and network camera industry since 1998, we offer complete surveillance camera systems, including day/night, vandal-resistant, and weatherproof IP cameras.</p>
        </div>
        <div class="resources">
            <a href="/support.aspx">Learn More</a>
        </div>
    </div>
</asp:Content>

