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
using Guna.UI.WinForms;

namespace BankmangmentA
{
    public partial class Employee : Form
    {
        SqlConnection con = Actions.connect;
        public Employee()
        {
            InitializeComponent();
        }
        private void gets()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from employee", con);
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
            SqlCommand cmd = new SqlCommand("insert into employee values(@e_id , @name  , @position, @salary)", con);
            cmd.Parameters.AddWithValue("@e_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@salary", textBox3.Text);
            cmd.Parameters.AddWithValue("@position", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Added Recorded Scuessfuly");
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            gets();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from employee where e_id = @e_id",con);
            cmd.Parameters.AddWithValue("@e_id", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Delete Scuesdfuly");
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("update  employee set e_id =@e_id , name =@name , salary =@salary , postion =@postion", con);
            cmd.Parameters.AddWithValue("@e_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@salary", textBox3.Text);
            cmd.Parameters.AddWithValue("@postion", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gets();
            MessageBox.Show("Update Recorded Scuessfuly");
        }
    }
}
