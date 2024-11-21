using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BankmangmentA
{
    internal class Actions
    {
        public static SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=BankADB;Integrated Security=True;Encrypt=False");

    }
}
