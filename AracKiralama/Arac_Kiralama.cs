using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    internal class Arac_Kiralama
    {
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Arac_Kiralama; user Id=postgres; password=123456");

        DataTable tablo;
        public void ekle_sil_güncelle(NpgsqlCommand komut, string sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public DataTable listele(NpgsqlDataAdapter adtr, string sorgu)
        {
            tablo = new DataTable();
            adtr = new NpgsqlDataAdapter(sorgu, baglanti);
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        public void Boş_Araçlar(ComboBox combo, string sorgu)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
            NpgsqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                combo.Items.Add(read["plaka"].ToString());

            }
            baglanti.Close();

        }
        public void TC_Ara(TextBox tcara,TextBox tc, TextBox adsoyad, TextBox telefon, string sorgu)
        {

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
            NpgsqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                tc.Text = read["tc"].ToString();
                adsoyad.Text = read["adsoyad"].ToString();
                telefon.Text = read["telefon"].ToString();

            }
            baglanti.Close();

        }
        public void ücret_Hesapla(ComboBox combokiraşekli, TextBox ucret, string sorgu)
        {

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
            NpgsqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (combokiraşekli.SelectedIndex == 0) ucret.Text = (int.Parse(read["kiraucreti"].ToString()) * 1).ToString();
                if (combokiraşekli.SelectedIndex == 1) ucret.Text = (int.Parse(read["kiraucreti"].ToString()) * 0.80).ToString();
                if (combokiraşekli.SelectedIndex == 2) ucret.Text = (int.Parse(read["kiraucreti"].ToString()) * 0.70).ToString();





            }
            baglanti.Close();

        }

        public void CombodanGetir(ComboBox araçlar, TextBox marka, TextBox seri, TextBox yil, TextBox renk, string sorgu)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
            NpgsqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                marka.Text = read["marka"].ToString();
                seri.Text = read["seri"].ToString();
                yil.Text = read["yil"].ToString();
                renk.Text = read["renk"].ToString();

            }
            baglanti.Close();

        }
        public void satışhesapla( Label lbl) 
        {

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select sum(tutar) from satış",baglanti);
            lbl.Text = "Toplam Tutar=" + komut.ExecuteScalar() + "TL";
            baglanti.Close();
        
        
        }
    }
}
