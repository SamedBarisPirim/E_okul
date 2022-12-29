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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-8842N4N;Initial Catalog=eokul;Integrated Security=True");
        public string numara;
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
          
            baglanti.Open();
            SqlCommand listele = new SqlCommand("select OGRAD,DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM  from TBLNOTLAR inner join TBLDERSLER on TBLNOTLAR.DERSID = TBLDERSLER.DERSID   inner join TBLOGRENCİLER on TBLNOTLAR.OGRID = TBLOGRENCİLER.OGRID  where TBLNOTLAR.OGRID = @p1",baglanti);
            listele.Parameters.AddWithValue("@p1", numara);
        
            SqlDataAdapter da = new SqlDataAdapter(listele);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            baglanti.Close();
        }
    }
}
