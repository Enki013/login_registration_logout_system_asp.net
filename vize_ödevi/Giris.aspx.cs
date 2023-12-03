using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vize_ödevi
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        protected void btnKayitYonlendir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kayit.aspx");
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı ve şifreyi al
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            // Kullanıcı adı ve şifre formatlarını kontrol et
            if (KullaniciAdiGecerliMi(kullaniciAdi) && SifreGecerliMi(sifre))
            {
                // Kullanıcıyı doğrula
                bool kullaniciDogrulandi = DogrulaKullanici(kullaniciAdi, sifre);

                if (kullaniciDogrulandi)
                {
                    // Eğer kullanıcı doğrulandıysa, oturum başlat ve NotOrtalama.aspx sayfasına yönlendir
                    Session["KullaniciAdi"] = kullaniciAdi;
                    Response.Redirect("NotOrtalama.aspx");
                }
                else
                {
                    // Eğer kullanıcı doğrulanamadıysa, geçersiz kullanıcı adı veya şifre mesajını göster
                    lblGirisDurumu.Text = "Geçersiz kullanıcı adı veya şifre.";
                }
            }
            else
            {
                // Eğer kullanıcı adı veya şifre formatı geçersizse, uygun bir mesaj göster
                lblGirisDurumu.Text = "Geçersiz kullanıcı adı veya şifre formatı.";
            }
        }


        private bool KullaniciAdiGecerliMi(string kullaniciAdi)
        {
            // Kullanıcı adı 3 ile 20 karakter arasında olmalıdır ve sadece harf, rakam ve alt çizgi (_) karakterlerini içerebilir.
            string kullaniciAdiRegex = @"^[a-zA-Z0-9_]{3,20}$";
            return Regex.IsMatch(kullaniciAdi, kullaniciAdiRegex);
        }

        private bool SifreGecerliMi(string sifre)
        {

            // Şifre karmaşıklığı kontrolü (en az bir büyük harf, bir küçük harf ve bir rakam içermelidir)
            if (!Regex.IsMatch(sifre, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
            {
                return false;
            }

            return true;
        }

        private bool DogrulaKullanici(string kullaniciAdi, string sifre)
        {
            // Kullanıcı bilgilerinin bulunduğu dosya yolu
            string dosyaYolu = Server.MapPath("~/App_Data/kullanicilar.txt");

            // Dosyadan satırları oku ve diziye aktar
            string[] satirlar = File.ReadAllLines(dosyaYolu);

            // Dosyadaki her bir satırı kontrol et
            foreach (string satir in satirlar)
            {
                // Satırdaki bilgileri virgülle ayırarak diziye aktar
                string[] bilgiler = satir.Split(',');

                // Eğer satırda iki eleman varsa ve kullanıcı adı ile şifre eşleşiyorsa
                if (bilgiler.Length == 2 && bilgiler[0] == kullaniciAdi && bilgiler[1] == sifre)
                {
                    return true; // Kullanıcı doğrulandı
                }
            }

            // Kullanıcı bulunamadı veya doğrulanamadı
            return false;
        }
        protected void lnkCikis_Click(object sender, EventArgs e)
        {
            // Oturumu temizle
            Session.Clear();

            // Oturumu sonlandır
            Session.Abandon();

            // Kullanıcıyı başka bir sayfaya yönlendirme
            Response.Redirect("Giris.aspx");
        }


    }
}