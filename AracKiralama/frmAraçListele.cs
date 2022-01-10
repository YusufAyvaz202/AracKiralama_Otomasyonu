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
    public partial class frmAraçListele : Form
    {
        Arac_Kiralama arackiralama = new Arac_Kiralama();

        public frmAraçListele()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            plakatxt.Text = satır.Cells["plaka"].Value.ToString();
            markacombo.Text = satır.Cells["marka"].Value.ToString();
            sericombo.Text = satır.Cells["seri"].Value.ToString();
            yiltxt.Text = satır.Cells["yil"].Value.ToString();
            renktxt.Text = satır.Cells["renk"].Value.ToString();
            kmtxt.Text = satır.Cells["km"].Value.ToString();
            yakitcombo.Text = satır.Cells["yakit"].Value.ToString();
            kiratxt.Text = satır.Cells["kiraucreti"].Value.ToString();
            pictureBox2.ImageLocation = satır.Cells["resim"].Value.ToString();
        }

        private void frmAraçListele_Load(object sender, EventArgs e)
        {
            yenileAraclarListesi();
            try
            {
                comboBox1.SelectedIndex = 0;
            }
            catch
            {

                ;
            }

        }

        private void yenileAraclarListesi()
        {
            string cümle = "select * from araç";
            NpgsqlDataAdapter adtr2 = new NpgsqlDataAdapter();
            dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = "update araç set marka=@marka,seri=@seri,yil=@yil,renk=@renk,km=@km,yakit=@yakit,kiraucreti=@kiraucreti,resim=@resim,tarih=@tarih where plaka=@plaka";
            NpgsqlCommand komut2 = new NpgsqlCommand();
            komut2.Parameters.AddWithValue("@plaka", plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", sericombo.Text);
            komut2.Parameters.AddWithValue("@yil", yiltxt.Text);
            komut2.Parameters.AddWithValue("@renk", renktxt.Text);
            komut2.Parameters.AddWithValue("@km", kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakit", yakitcombo.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(kiratxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox2.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";


            yenileAraclarListesi();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from araç where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
            NpgsqlCommand komut2 = new NpgsqlCommand();
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";
            yenileAraclarListesi();

        }

        private void markacombo_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    yenileAraclarListesi();
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    string cümle = "select * from araç where durum='BOŞ'";
                    NpgsqlDataAdapter adtr2 = new NpgsqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    string cümle = "select * from araç where durum='DOLU'";
                    NpgsqlDataAdapter adtr2 = new NpgsqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
            }
            catch
            {

                ;
            }
        }
    }
}
