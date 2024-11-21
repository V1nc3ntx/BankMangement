using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BankmangmentA
{
    public partial class Transcations : Form
    {
        SqlConnection con = Actions.connect;

        public Transcations()
        {
            InitializeComponent();
        }

        private void Transcations_Load(object sender, EventArgs e)
        {
            gets();
        }

        private void gets()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from transcations", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into transcations values(@t_id , @trans_type , @amount , @trans_date , @account_id)", con);
            cmd.Parameters.AddWithValue("@t_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@trans_type", textBox2.Text);
            cmd.Parameters.AddWithValue("@amount", textBox3.Text);
            cmd.Parameters.AddWithValue("@trans_date", gunaDateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@account_id", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Added Recorded Scuessfuly");
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from transcations where t_id = @t_id" , con);
            cmd.Parameters.AddWithValue("@t_id",textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Recorded");
            gets();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("update transcations set t_id =@t_id , trans_type =@trans_type , amount = @amount , trans_date =@trans_date , account_id =@account_id", con);
            cmd.Parameters.AddWithValue("@t_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@trans_type", textBox2.Text);
            cmd.Parameters.AddWithValue("@amount", textBox3.Text);
            cmd.Parameters.AddWithValue("@trans_date", gunaDateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@account_id", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Update Recorded Scuessfuly");
        }
    }
}
