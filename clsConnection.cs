using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    internal class clsConnection
    {
        public static SqlConnection con = new SqlConnection();
    }
}
