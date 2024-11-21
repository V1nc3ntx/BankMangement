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
using System.Diagnostics;
using System.Management;

namespace BankmangmentA
{
    public partial class Loans : Form
    {
        SqlConnection con = Actions.connect;


        public Loans()
        {
            InitializeComponent();
        }

        private void gets()
        {

            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from loans", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into loans values(@loan_id , @loan_type , @amount , @interest_rate,@loan_date , @customer_name)", con);
            cmd.Parameters.AddWithValue("@loan_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@loan_type", textBox2.Text);
            cmd.Parameters.AddWithValue("@amount", textBox3.Text);
            cmd.Parameters.AddWithValue("@interest_rate", textBox4.Text);
            cmd.Parameters.AddWithValue("@loan_date", gunaDateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@customer_name", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Scuessfuly Your Recorded");

        }

        private void Loans_Load(object sender, EventArgs e)
        {
            gets();

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from loans where loan_id = @loan_id", con);
            cmd.Parameters.AddWithValue("@loan_id", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Scuessfuly Delete Recorded");

        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("update  loans set loan_type =@loan_type , amount= @amount , interest_rate = @interest_rate,loan_date = @loan_date , customer_name = @customer_name where loan_id =@loan_id", con);
            cmd.Parameters.AddWithValue("@loan_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@loan_type", textBox2.Text);
            cmd.Parameters.AddWithValue("@amount", textBox3.Text);
            cmd.Parameters.AddWithValue("@interest_rate", textBox4.Text);
            cmd.Parameters.AddWithValue("@loan_date", gunaDateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@customer_name", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Scuessfuly Your Recorded Update");
        }
    }
}
