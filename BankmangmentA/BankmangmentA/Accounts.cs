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

namespace BankmangmentA
{
    public partial class Accounts : Form
    {
        SqlConnection con = Actions.connect;
        public Accounts()
        {
            InitializeComponent();
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            gets();
            gunaDateTimePicker1.Value.CompareTo(DateTime.Now);

        }

        private void gets()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Account", con);
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
            SqlCommand cmd = new SqlCommand("insert into account values(@account_id , @account_name , @balance , @date_opened , @customer_name)" , con);
            cmd.Parameters.AddWithValue("@account_id" ,textBox1.Text);
            cmd.Parameters.AddWithValue("@account_name" , textBox2.Text);
            cmd.Parameters.AddWithValue("@balance" , textBox3.Text);
            cmd.Parameters.AddWithValue("@date_opened", gunaDateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@customer_name", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Added Recorded Scuessfuly");
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {




        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Account where Account_ID = @account_id" , con);
            cmd.Parameters.AddWithValue("@account_id" , textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Scuessfuly Delete Recorded");
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("update Account set Account_name =@account_name , Balance= @balance , Date_Opened = @date_opened, Customer_name = @customer_name where Account_ID = @account_id", con);
            cmd.Parameters.AddWithValue("@account_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@account_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@balance", textBox3.Text);
            cmd.Parameters.AddWithValue("@date_opened", gunaDateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@customer_name", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Scuessfuly Update your recorded");
        }
    }

}
