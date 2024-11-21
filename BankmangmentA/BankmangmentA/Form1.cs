using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankmangmentA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAccount_Click(object sender, EventArgs e)
        {
            Accounts acc = new Accounts();
            acc.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Show();
        }

        private void gunaAdvenceTileButton2_Click(object sender, EventArgs e)
        {
            Loans lo = new Loans();
            lo.Show();
        }

        private void gunaAdvenceTileButton3_Click(object sender, EventArgs e)
        {
            Transcations tr = new Transcations();
            tr.Show();

        }

        private void gunaAdvenceTileButton4_Click(object sender, EventArgs e)
        {
            Employee dd = new Employee();
            dd.Show();  
        }

        private void gunaAdvenceTileButton5_Click(object sender, EventArgs e)
        {
            Dashboard dsh = new Dashboard();
            dsh.Show();
        }
    }
}
