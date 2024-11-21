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
    public partial class Dashboard : Form
    {
        SqlConnection con = Actions.connect;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            employee();
            loans();
            customer();
        }
        private void employee()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from employee", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                lb_employee.Text = count.ToString();
            }
            else
            {
                lb_employee.Text = "0";

            }
        }

        private void customer()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from customer", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                lb_customer.Text = count.ToString();
            }
            else
            {
                lb_customer.Text = "0";

            }
        }

        private void loans()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from loans", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                lb_loans.Text = count.ToString();
            }
            else
            {
                lb_loans.Text = "0";

            }
        }

    }
}
