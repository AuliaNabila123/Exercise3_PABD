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
    public partial class Form4 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nabilaPABDDataSet.Transaksi' table. You can move, or remove it, as needed.
            this.transaksiTableAdapter.Fill(this.nabilaPABDDataSet.Transaksi);


        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LKP54HAE\\MSSQLSERVER01;database=NabilaPABD;;User ID=sa;Password=Purworejo123");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Transaksi values (@Nama_Pelanggan,@Tgl_Transaksi,@Jenis_Pembayaran)", con);
            cmd.Parameters.AddWithValue("@Nama_Pelanggan", txtNama.Text);
            cmd.Parameters.AddWithValue("@Tgl_Transaksi", txtTgl.Text);
            cmd.Parameters.AddWithValue("@Jenis_Pembayaran", txtBayar.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("berhasil");

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = nabilaPABDDataSet.Tables["Transaksi"];
            dr = dt.NewRow();
            dr[0] = txtNama.Text = "";
            dr[1] = txtTgl.Text = "";
            dr[2] = txtBayar.Text = "";
            dt.Rows.Add(dr);
            transaksiTableAdapter.Update(nabilaPABDDataSet);
            txtNama.Text = System.Convert.ToString(dr[0]);
            txtNama.Enabled = false;
            txtTgl.Enabled = false;
            txtBayar.Enabled = false;
            this.transaksiTableAdapter.Fill(this.nabilaPABDDataSet.Transaksi);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtNama.Text;
            dr = nabilaPABDDataSet.Tables["Barang"].Rows.Find(code);
            dr.Delete();
            transaksiTableAdapter.Update(nabilaPABDDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }
    }
}
