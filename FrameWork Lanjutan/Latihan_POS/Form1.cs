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
using MySql.Data.MySqlClient;





namespace Latihan_Posting
{
    public partial class Form1 : Form
    {
        string maks;
        MySqlConnection connect = new MySqlConnection("Server=127.0.0.1;Database=pos;Uid=root;Pwd=12345");
        DataTable oDT;
        MySqlDataAdapter oDA;
        MySqlCommand command;
        public Form1()
        {
            InitializeComponent();
        }
        
        void Kosongkan()
        {
            command = new MySqlCommand("select ifnull(max(id),0)+1 from barang", connect);
            oDA = new MySqlDataAdapter(command);
            oDT = new DataTable();
            oDA.Fill(oDT);
            maks = oDT.Rows[0][0].ToString();
            txtID.Text = oDT.Rows[0][0].ToString();
            txtNama.Text = "";
            txtJumlah.Text = "";
            txtHarga.Text = "";
        }
        void Tampilsemua()
        {
            command = new MySqlCommand("select * from barang", connect);
            oDA = new MySqlDataAdapter(command);
            oDT = new DataTable();
            oDA.Fill(oDT);

            dataGridView1.DataSource = oDT;
        }
        void masukkanData()
        {
            try
            {
                connect.Open();
                command = new MySqlCommand("insert into barang values(@id,@nama,@jumlahawal,@hargajual)", connect);
                command.Parameters.AddWithValue("@id", txtID.Text);
                command.Parameters.AddWithValue("@nama", txtNama.Text);
                command.Parameters.AddWithValue("@jumlahawal", int.Parse(txtJumlah.Text));
                command.Parameters.AddWithValue("@hargajual", Convert.ToDecimal(txtHarga.Text));
                command.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Tampilsemua();
            Kosongkan();
        }
        void UbahData()
        {
            connect.Open();
            try
            {
                command = new MySqlCommand("update barang set ,nama=@nama,jumlahawal=@jumlahawal,hargajual=@hargajual, where id=@id", connect);
                command.Parameters.AddWithValue("@id", txtID.Text);
                command.Parameters.AddWithValue("@nama", txtNama.Text);
                command.Parameters.AddWithValue("@jumlahawal", int.Parse(txtJumlah.Text));
                command.Parameters.AddWithValue("@hargajual", Convert.ToDecimal(txtHarga.Text));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Tampilsemua();
            Kosongkan();
            connect.Close();
        }
        private void Keluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Kosongkan();
        }

        private void Simpan_Click(object sender, EventArgs e)
        { 
            if (txtID.Text == maks)
            {
                masukkanData();
            }else
            {
                UbahData();
            }
        }

    }
}
