using Dapper;
using System;
using System.Collections;
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

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        private readonly SqlConnection sqlCon = new SqlConnection(connectionString);
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

        public List<dynamic> ExecuteSelectWithDapper(string query)
        {
            try
            {

                var result = new List<dynamic>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    result = connection.Query<dynamic>(query).ToList();
                    connection.Close();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<dynamic> ExecuteSelectWithOptionDapper(string query, object paramObject)
        {
            try
            {

                var result = new List<dynamic>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    result = connection.Query<dynamic>(query, paramObject).ToList();
                    connection.Close();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object ExecuteQueryWithParamDapper(string query, object paramObject)
        {
            try
            {
                var result = new object();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    result = connection.Execute(query, paramObject);
                    connection.Close();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ExecuteBulkInsertWithDapper(List<object> bulkObjects)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.InsertBulk(bulkObjects);
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
