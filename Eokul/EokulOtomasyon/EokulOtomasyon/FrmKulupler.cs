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
    public partial class FrmKulupler : Form
    {
        public FrmKulupler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-8842N4N;Initial Catalog=eokul;Integrated Security=True");

        void listele()
        {
            
            
            SqlDataAdapter da = new SqlDataAdapter("select  * from TBLKULUP",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            

        }

        private void FrmKulupler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into TBLKULUP (KULUPAD) values (@p1)",baglanti);
            ekle.Parameters.AddWithValue("@p1",textBox2.Text);
            ekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaydınız Bşarıyla Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupıd.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text =dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete from TBLKULUP where KULUPID=@p1", baglanti);
            sil.Parameters.AddWithValue("@p1",TxtKulupıd.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silinsin mi?","Uyarı",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            listele();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand gun = new SqlCommand("Update TBLKULUP  set KULUPAD=@p1 where KULUPID=@p2",baglanti);
            gun.Parameters.AddWithValue("@p1",textBox2.Text);
            gun.Parameters.AddWithValue("@p2", TxtKulupıd.Text);
            gun.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellensin mi?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
