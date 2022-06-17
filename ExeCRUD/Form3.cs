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

namespace ExeCRUD
{
    public partial class Form3 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nabilaPABDDataSet.Barang' table. You can move, or remove it, as needed.
            this.barangTableAdapter.Fill(this.nabilaPABDDataSet.Barang);

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LKP54HAE\\MSSQLSERVER01;database=NabilaPABD;;User ID=sa;Password=Purworejo123");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Barang values (@Id_Barang,@Nama_Barang,@Harga)", con);
            cmd.Parameters.AddWithValue("@Id_Barang", txtId.Text);
            cmd.Parameters.AddWithValue("@Nama_Barang", txtBrg.Text);
            cmd.Parameters.AddWithValue("@Harga", txtHarga.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("berhasil");

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = nabilaPABDDataSet.Tables["Barang"];
            dr = dt.NewRow();
            dr[0] = txtId.Text = "";
            dr[1] = txtBrg.Text = "";
            dr[2] = txtHarga.Text = "";
            dt.Rows.Add(dr);
            barangTableAdapter.Update(nabilaPABDDataSet);
            txtId.Text = System.Convert.ToString(dr[0]);
            txtId.Enabled = false;
            txtBrg.Enabled = false;
            txtHarga.Enabled = false;
            this.barangTableAdapter.Fill(this.nabilaPABDDataSet.Barang);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtId.Text;
            dr = nabilaPABDDataSet.Tables["Barang"].Rows.Find(code);
            dr.Delete();
            barangTableAdapter.Update(nabilaPABDDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }
    }
}
