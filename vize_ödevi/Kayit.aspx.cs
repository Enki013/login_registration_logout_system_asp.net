
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
    public partial class WebForm1 : System.Web.UI.Page
    {


        protected bool KullaniciAdiUygunluguKontrol(string kullaniciAdi)
        {
            // Kullanıcı adı 3 ile 20 karakter arasında olmalıdır ve sadece harf, rakam ve alt çizgi içerebilir.
            string kullaniciAdiRegex = @"^[a-zA-Z0-9_]{3,20}$";
            return Regex.IsMatch(kullaniciAdi, kullaniciAdiRegex);
        }

        protected bool SifreUygunluguKontrol(string sifre)
        {
            // Şifre en az 8 karakter uzunluğunda olmalıdır ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.
            string sifreRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
             return Regex.IsMatch(sifre, sifreRegex);
        }

        protected void btnKayit_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;
            string sifreTekrar = txtSifreTekrar.Text;

            string dosyaYolu = Server.MapPath("~/App_Data/kullanicilar.txt");

            if (KullaniciKayitliMi(dosyaYolu, kullaniciAdi))
            {
                // Kullanıcı adı zaten kayıtlıysa, hata mesajı göster
                lblKayitDurumu.Text = "Bu kullanıcı adı zaten kayıtlıdır. Lütfen farklı bir kullanıcı adı seçin.";
            }
            else if (sifre != sifreTekrar)
            {
                // Şifreler eşleşmiyorsa, hata mesajı göster
                lblKayitDurumu.Text = "Şifreler eşleşmiyor. Lütfen kontrol edin.";
            }
            else
            {
                bool kullaniciAdiUygun = KullaniciAdiUygunluguKontrol(kullaniciAdi);
                bool sifreUygun = SifreUygunluguKontrol(sifre);

                if (!kullaniciAdiUygun)
                {
                    // Kullanıcı adı kurallarına uymuyorsa, hata mesajı göster
                    lblKullaniciAdiKurallari.Text = "-Kullanıcı adı 3 ile 20 karakter arasında olmalıdır ve sadece harf, rakam ve alt çizgi içerebilir.";
                }
                else
                {
                    lblKullaniciAdiKurallari.Text = ""; // Kullanıcı adı kurallarına uygunsa mesajı temizle
                }

                if (!sifreUygun)
                {
                    // Şifre kurallarına uymuyorsa, hata mesajı göster
                    lblSifreKurallari.Text = "-Şifre en az 8 karakter uzunluğunda olmalıdır ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.";
                }
                else
                {
                    lblSifreKurallari.Text = ""; // Şifre kurallarına uygunsa mesajı temizle
                }

                if (!kullaniciAdiUygun || !sifreUygun)
                {
                    // Kullanıcı adı veya şifre uygun değilse, kayıt başarısız mesajını göster
                    lblKayitDurumu.Text = "Kayıt başarısız. Lütfen giriş bilgilerinizi kontrol edin.";
                }
                else
                {
                    // Kullanıcı adı ve şifreyi birleştirerek kayıt bilgisini oluşturma
                    string kayitBilgisi = kullaniciAdi + "," + sifre;

                    // Kullanıcıların kaydedildiği dosyanın yolunu belirleme

                    // Dosyada aynı kullanıcı adının olup olmadığını kontrol etme
                    if (KullaniciKayitliMi(dosyaYolu, kullaniciAdi))
                    {
                        // Eğer aynı kullanıcı adı zaten kayıtlıysa, hata mesajı göster
                        lblKayitDurumu.Text = "Bu kullanıcı adı zaten kayıtlıdır. Lütfen farklı bir kullanıcı adı seçin.";
                    }
                    else
                    {
                        // Kullanıcıyı başarıyla kaydetme işlemi
                        File.AppendAllText(dosyaYolu, kayitBilgisi + Environment.NewLine);
                        lblKayitDurumu.Text = "Kayıt başarıyla tamamlandı.";
                    }
                }
            }
        }




        private bool KullaniciKayitliMi(string dosyaYolu, string kullaniciAdi)
        {
            // Bu fonksiyon, verilen kullanıcı adının dosyada olup olmadığını kontrol eder.

            // Dosyanın tüm satırlarını bir diziye yükleme
            string[] satirlar = File.ReadAllLines(dosyaYolu);
            // Her bir satırı kontrol etmek için döngü 

            foreach (string satir in satirlar)
            {
                // Her satırı virgül karakterine göre ayırma, böylece kullanıcı adı ve diğer bilgileri elde edebiliriz

                string[] bilgiler = satir.Split(',');

                // Eğer satırın en az bir öğesi varsa ve kullanıcı adı belirtilen kullanıcı adına eşitse,
                //true değeri döndürür
              
                if (bilgiler.Length > 0 && bilgiler[0] == kullaniciAdi)
                {
                    return true; // Kullanıcı adı zaten kayıtlı
                }
            }
            // Eğer döngü sona ererse ve kullanıcı adı dosyada bulunamazsa, false değerini döner
            return false; // Kullanıcı adı kayıtlı değil
        }

        protected void btnGirisYonlendir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Giris.aspx");
        }
    }
}
