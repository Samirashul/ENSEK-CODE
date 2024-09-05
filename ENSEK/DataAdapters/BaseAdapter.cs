using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DbExtensions;
using ENSEK.Interfaces;

namespace ENSEK.DataAdapters
{
    public class BaseAdapter : iBaseAdapter
    {

        private string _connectionString = "server=localhost;database=ENSEK;integrated Security=SSPI;";

        public string GetConnectionString()
        { 
            return _connectionString;
        }

        public bool CheckIfFieldExists(string table, string column, string id)
        {

            using (SqlConnection _con = new SqlConnection(_connectionString))
            {
                string queryStatement = $"SELECT * FROM dbo.{table} WHERE {column} = {id}";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    DataTable tempTable = new DataTable("TempTable");

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(tempTable);
                    _con.Close();

                    return tempTable.Rows.Count>0 ? true : false;

                }
            }
        }

        public bool CheckIfEntryExists(string table,Dictionary<string, string> parameters)
        {
            using (SqlConnection _con = new SqlConnection(_connectionString))
            {
                var query = new SqlBuilder().SELECT("*")
                    .FROM(table);

                foreach (KeyValuePair<string, string> kvp in parameters)
                    query.WHERE($"{kvp.Key} = '{kvp.Value}'");

                using (SqlCommand _cmd = new SqlCommand(query.ToString(), _con))
                {
                    DataTable tempTable = new DataTable("TempTable");

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(tempTable);
                    _con.Close();

                    return tempTable.Rows.Count > 0 ? true : false;

                }
            }
        }

        public string ConvertDateTime(DateTime dt)
        {
            return $"CONVERT(DATETIME, '{dt}', 103)";
        }
    }
}