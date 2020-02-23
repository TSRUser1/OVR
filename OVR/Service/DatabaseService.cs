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
    public class DatabaseService
    {
        private readonly SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public DataTable ExecuteSelectQuery(string query)
        {
            try
            {
                var result = new DataTable();
                sqlCon.Open();
                var sqlComm = new SqlCommand(query, sqlCon);
                SqlDataReader queryCommandReader = sqlComm.ExecuteReader();
                result.Load(queryCommandReader);
                sqlCon.Close();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ExecuteSelectQueryWithOptions(string query, List<SqlParameter> sqlParameters)
        {
            try
            {
                var result = new DataTable();
                sqlCon.Open();
                var sqlComm = new SqlCommand(query, sqlCon);
                if (sqlParameters.Any())
                {
                    foreach (var sqlParameter in sqlParameters)
                    {
                        sqlComm.Parameters.Add(sqlParameter);
                    }
                }
                SqlDataReader queryCommandReader = sqlComm.ExecuteReader();
                result.Load(queryCommandReader);
                sqlCon.Close();

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
