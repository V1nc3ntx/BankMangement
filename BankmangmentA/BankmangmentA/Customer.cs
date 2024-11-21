using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace BankmangmentA
{
    public partial class Customer : Form
    {
        SqlConnection con = Actions.connect;
        public Customer()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into customer values(@customer_id , @customer_name , @phone , @email , @adress)", con);
            cmd.Parameters.AddWithValue("@customer_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@customer_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@adress", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Added Recorded Scuessfuly");
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from customer where customer_id = @account_id", con);
            cmd.Parameters.AddWithValue("@account_id", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Scuessfuly Delete Recorded");
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("update customer set customer_name= @customer_name , phone = @phone, email = @email , adress = @adress where customer_id = @customer_id", con);
            cmd.Parameters.AddWithValue("@customer_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@customer_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@adress", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Scuessfuly Update your recorded");
        }

        private void gets()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from customer" , con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            gets();
        }
    }
}
