using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class frmMüsteriEkle : Form
    {

        Arac_Kiralama arac_Kiralama = new Arac_Kiralama();

        public frmMüsteriEkle()
        {
            InitializeComponent();
        }

        private void frmMüsteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = "insert into public.musteri(tc,adsoyad,telefon,adres,email) values(@tc,@adsoyad,@telefon,@adres,@email)";
            NpgsqlCommand komut2 = new NpgsqlCommand();
            komut2.Parameters.AddWithValue("@tc",txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad",txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon",txtTelefon.Text);
            komut2.Parameters.AddWithValue("@adres",txtAdres.Text);
            komut2.Parameters.AddWithValue("@email",txtEmail.Text);

            arac_Kiralama.ekle_sil_güncelle(komut2,cümle);

            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            
        }
    }
}
