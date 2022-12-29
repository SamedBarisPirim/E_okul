using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace EokulOtomasyon
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DataTable2TableAdapter ds =  new DataSet1TableAdapters.DataTable2TableAdapter();
        private void BtnAra_Click(object sender, EventArgs e)
        {
          dataGridView1.DataSource=  ds.NotListele(int.Parse(TxtID.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-8842N4N;Initial Catalog=eokul;Integrated Security=True");

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLDERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DERSAD";
            comboBox1.ValueMember = "DERSID";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int sinav1,sinav2,sinav3,proje;
            double ort;
            sinav1  =Convert.ToInt16(TxtSinav1.Text);
            sinav2 =Convert.ToInt16(TxtSinav2.Text);
            sinav3= Convert.ToInt16(TxtSinav3.Text);
            proje=Convert.ToInt16(TxtProje.Text);
            ort=(sinav1+sinav2+sinav3+proje)/4;
            TxtOrtalama.Text =ort.ToString();
            if(ort>=50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NOTGUNCELLE(byte.Parse(TxtSinav1.Text),byte.Parse(TxtSinav2.Text),byte.Parse(TxtSinav3.Text),byte.Parse(TxtProje.Text),decimal.Parse(TxtOrtalama.Text),int.Parse(TxtID.Text),byte.Parse(comboBox1.SelectedValue.ToString()));
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            ds.NOTSİL(int.Parse(TxtID.Text));
            TxtID.Clear();
            TxtSinav1.Clear();
            TxtSinav2.Clear();
            TxtSinav3.Clear();
            TxtProje.Clear();
            TxtOrtalama.Clear();
            TxtDurum.Clear();
            MessageBox.Show("Temizlendi");
        }
    }
}
