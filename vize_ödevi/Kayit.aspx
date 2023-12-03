<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kayit.aspx.cs" Inherits="vize_ödevi.WebForm1" %>

<!DOCTYPE html>
<html lang="tr">
<head>
    <title>Signup</title>
    <link rel="stylesheet" href="assets/Kayit.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <!-- Kayıt formu -->
            <div class="registration form">
                <!-- Başlık -->
                <header>Signup</header>

                <!-- Kullanıcı adı, şifre ve şifre tekrarı giriş kutuları -->
                <asp:TextBox ID="txtKullaniciAdi" runat="server" placeholder="Kullanıcı adı girin"></asp:TextBox>
                <asp:TextBox ID="txtSifre" runat="server" TextMode="Password" placeholder="Şifre oluştur"></asp:TextBox>
                <asp:TextBox ID="txtSifreTekrar" runat="server" TextMode="Password" placeholder="Şifreyi onayla"></asp:TextBox>
                <asp:Button ID="btnKayit" runat="server" CssClass="button" Text="Kayıt Ol" OnClick="btnKayit_Click" />

                <!-- Giriş yap linki -->
                <div class="signup">
                    Zaten hesabın var mı?
                    <asp:LinkButton runat="server" Text="Giriş Yap" OnClick="btnGirisYonlendir_Click" CssClass="signup" />
                </div>

                <!-- Kayıt durumu ve hata mesajları için etiketler -->
                <asp:Label ID="lblKayitDurumu" runat="server" Text="" />
                <asp:Label ID="lblKullaniciAdiKurallari" runat="server" CssClass="error-message"></asp:Label>
                <asp:Label ID="lblSifreKurallari" runat="server" CssClass="error-message"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
