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
    public partial class frmSatış : Form
    {
        public frmSatış()
        {
            InitializeComponent();
        }
        Arac_Kiralama arac= new Arac_Kiralama();
        private void frmSatış_Load(object sender, EventArgs e)
        {

            string sorgu2 = "select * from satış";
            NpgsqlDataAdapter adtr2 = new NpgsqlDataAdapter();

            dataGridView1.DataSource = arac.listele(adtr2,sorgu2);
            arac.satışhesapla(label1);
        }
    }
}
