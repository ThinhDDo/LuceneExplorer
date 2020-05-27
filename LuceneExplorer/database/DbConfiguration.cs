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
        private static string DATA_SOURCE = @"DESKTOP-A5TNJRP\SQLEXPRESS01";
        private static string DATABASE = "LuceneDB";
        private static string USER = "";
        private static string PASSWORD = "";
        //Data Source = DESKTOP - A5TNJRP\SQLEXPRESS01;Initial Catalog = LuceneDB; Integrated Security = True
        public static SqlConnection GetDBConnection()
        {
            string connString = $"Data Source={DATA_SOURCE};Initial Catalog={DATABASE};Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
