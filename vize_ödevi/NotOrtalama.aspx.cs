
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vize_ödevi
{
    public partial class WebForm3 : System.Web.UI.Page
    {
 

        protected void btnOrtalamaHesapla_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan notları saklamak için değişkenler
            double not1, not2, not3;

            // Kullanıcının girdiği metin kutularından notları double türüne dönüştürme
            if (double.TryParse(txtNot1.Text, out not1) && double.TryParse(txtNot2.Text, out not2) && double.TryParse(txtNot3.Text, out not3))
            {
                // Girilen notların geçerli olduğunu ve 1 ile 100 arasında olduğunu kontrol etme
                if (not1 >= 1 && not1 <= 100 && not2 >= 1 && not2 <= 100 && not3 >= 1 && not3 <= 100)
                {
                    // Notların ortalamasını hesaplama
                    double ortalama = (not1 + not2 + not3) / 3.0;

                    // Hesaplanan ortalama değerini etikete atayın ve virgülden sonra 2 basamak gösterme
                    lblOrtalamaSonuc.Text = "Ortalama: " + ortalama.ToString("F2");
                }
                else
                {
                    // Notlar 1-100 arasında değilse kullanıcıya bilgi verme
                    lblOrtalamaSonuc.Text = "Notlar 1-100 arasında olmalıdır.";
                }
            }
            else
            {
                // Geçerli bir sayısal değer girilmediyse kullanıcıya bilgi verme
                lblOrtalamaSonuc.Text = "Geçerli notlar girin.";
            }
        }

        protected void cikisYap_Click(object sender, EventArgs e)
        {
            // Oturumu temizle
            Session.Clear();

            // Oturumu sonlandır
            Session.Abandon();

            // Kullanıcıyı başka bir sayfaya yönlendirme (örneğin giriş sayfasına)
            Response.Redirect("Giris.aspx");
        }
    }
}
