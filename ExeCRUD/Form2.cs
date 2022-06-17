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
    public partial class Form2 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;

        public Form2()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
       
            // TODO: This line of code loads data into the 'nabilaPABDDataSet.Pelanggan' table. You can move, or remove it, as needed.
            this.pelangganTableAdapter.Fill(this.nabilaPABDDataSet.Pelanggan);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LKP54HAE\\MSSQLSERVER01;database=NabilaPABD;;User ID=sa;Password=Purworejo123");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Pelanggan values (@Nama_Pelanggan,@Alamat,@No_Telp)", con);
            cmd.Parameters.AddWithValue("@Nama_Pelanggan", txtNama.Text);
            cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
            cmd.Parameters.AddWithValue("@No_Telp", txtNo.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("berhasil");
        }

    

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = nabilaPABDDataSet.Tables["Pelanggan"];
            dr = dt.NewRow();
            dr[0] = txtNama.Text = "";
            dr[1] = txtAlamat.Text = "";
            dr[2] = txtNo.Text = "";
            dt.Rows.Add(dr);
            pelangganTableAdapter.Update(nabilaPABDDataSet);
            txtNama.Text = System.Convert.ToString(dr[0]);
            txtNama.Enabled = false;
            txtAlamat.Enabled = false;
            txtNo.Enabled = false;
            this.pelangganTableAdapter.Fill(this.nabilaPABDDataSet.Pelanggan);
            button1.Enabled = true;
            cmdSave.Enabled = false;

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtNama.Text;
            dr = nabilaPABDDataSet.Tables["Pelanggan"].Rows.Find(code);
            dr.Delete();
            pelangganTableAdapter.Update(nabilaPABDDataSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }
    }
}
