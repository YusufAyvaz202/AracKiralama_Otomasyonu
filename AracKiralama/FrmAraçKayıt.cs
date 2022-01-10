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
    public partial class FrmAraçKayıt : Form
    {
        Arac_Kiralama arackiralama = new Arac_Kiralama();
        public FrmAraçKayıt()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sericombo.Items.Clear();
                if (markacombo.SelectedIndex == 0)
                {
                    sericombo.Items.Add("Astra");
                    sericombo.Items.Add("Corsa");
                }
                else if (markacombo.SelectedIndex == 1)
                {
                    sericombo.Items.Add("Megane");
                    sericombo.Items.Add("Clio");
                }
                else if (markacombo.SelectedIndex == 2)
                {
                    sericombo.Items.Add("Linea");
                    sericombo.Items.Add("Egea");
                }
                else if (markacombo.SelectedIndex == 3)
                {
                    sericombo.Items.Add("Fiesta");
                    sericombo.Items.Add("Focus");
                }

            }
            catch
            {

                ;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = "insert into araç(plaka,marka,seri,yil,renk,km,yakit,kiraucreti,resim,tarih,durum) values(@plaka,@marka,@seri,@yil,@renk,@km,@yakit,@kiraucreti,@resim,@tarih,@durum)";
            NpgsqlCommand komut2 = new NpgsqlCommand();

            komut2.Parameters.AddWithValue("@plaka", plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", sericombo.Text);
            komut2.Parameters.AddWithValue("@yil", yiltxt.Text);
            komut2.Parameters.AddWithValue("@renk", renktxt.Text);
            komut2.Parameters.AddWithValue("@km", kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakit", yakitcombo.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(kiratxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durum", "BOŞ");

            arackiralama.ekle_sil_güncelle(komut2,cümle);

            sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";

            pictureBox1.ImageLocation = "";
            
        }
    }
}
