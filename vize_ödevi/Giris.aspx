<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="vize_ödevi.WebForm2" %>

<!DOCTYPE html>
<html lang="tr">
<head>
    <title>Login</title>
    <link rel="stylesheet" href="assets/Giris.css"> <!-- Stil dosyasına referans -->
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login form">
                <header>Login</header> <!-- Giriş başlığı -->
                <asp:TextBox ID="txtKullaniciAdi" runat="server" placeholder="Kullanıcı adı" CssClass="login-input" /> <!-- Kullanıcı adı giriş kutusu -->
                <asp:TextBox ID="txtSifre" runat="server" TextMode="Password" placeholder="Şifre" CssClass="login-input" /> <!-- Şifre giriş kutusu -->
                <asp:Button ID="btnGiris" runat="server" Text="Giriş Yap" OnClick="btnGiris_Click" CssClass="button" /> <!-- Giriş yap butonu -->
                <div class="signup">
                    Hesabın yok mu? <!-- Kayıt olma mesajı -->
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Kayıt Ol" OnClick="btnKayitYonlendir_Click" CssClass="signup-link" /> <!-- Kayıt ol butonu -->
                </div>
                <asp:Label ID="lblGirisDurumu" runat="server" Text="" /> <!-- Giriş durumu etiketi -->
            </div>
        </div>
    </form>
</body>
</html>
