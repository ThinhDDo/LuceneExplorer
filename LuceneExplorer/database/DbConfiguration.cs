using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneExplorer.database
{
    public class DbConfiguration
    {
        private static string DATA_SOURCE = "DESKTOP-P6LTB96";
        private static string DATABASE = "LuceneDB";
        private static string USER = "sa";
        private static string PASSWORD = "1234";
        //Data Source = DESKTOP - A5TNJRP\SQLEXPRESS01;Initial Catalog = LuceneDB; Integrated Security = True
        public static SqlConnection GetDBConnection()
        {
            string connString = $"Data Source={DATA_SOURCE};Initial Catalog={DATABASE};Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
