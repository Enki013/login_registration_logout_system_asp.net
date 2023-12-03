<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotOrtalama.aspx.cs" Inherits="vize_ödevi.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Not Ortalama Sayfası</title>
    <!-- Stil dosyasına referans -->
    <link rel="stylesheet" href="assets/NotOrtalama.css"/>
</head>
<body>
    <!-- Form etiketi başlangıcı -->
    <form id="form1" runat="server">
        <!-- Navbar bölümü -->
        <div class="navbar">
            <!-- Çıkış yap butonu -->
            <asp:Button ID="Button1" runat="server" Text="Çıkış Yap" OnClick="cikisYap_Click" CssClass="logout-button" />
        </div>
        <!-- Ana içerik container'ı -->
        <div class="container">
            <!-- Not giriş kutuları -->
            <asp:TextBox ID="txtNot1" runat="server" placeholder="Not 1 (1-100)" CssClass="textbox" />
            <asp:TextBox ID="txtNot2" runat="server" placeholder="Not 2 (1-100)" CssClass="textbox" />
            <asp:TextBox ID="txtNot3" runat="server" placeholder="Not 3 (1-100)" CssClass="textbox" />
            <!-- Ortalama Hesapla butonu -->
            <asp:Button ID="btnOrtalamaHesapla" runat="server" Text="Ortalama Hesapla" OnClick="btnOrtalamaHesapla_Click" CssClass="button" />
            <!-- Ortalama sonucunu gösteren etiket -->
            <asp:Label ID="lblOrtalamaSonuc" runat="server" Text="" CssClass="result" />
        </div>
    </form>
</body>
</html>
