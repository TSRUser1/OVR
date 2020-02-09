using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Service
{
    class Database
    {
        private readonly SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public DataTable ExecuteQuery(string query)
        {
            var result = new DataTable();

            sqlCon.Open();
            var sqlComm = new SqlCommand(query, sqlCon);
            SqlDataReader queryCommandReader = sqlComm.ExecuteReader();
            result.Load(queryCommandReader);

            return result;
        }
    }
}
