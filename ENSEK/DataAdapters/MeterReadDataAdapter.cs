using ENSEK.Models;
using System.Data;
using System.Data.SqlClient;

namespace ENSEK.DataAdapters
{
    public class MeterReadDataAdapter : BaseAdapter
    {
        public bool InsertMeterRead(MeterRead meterRead)
        {
            using (SqlConnection _con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand _cmd = new SqlCommand($"INSERT INTO dbo.MeterRead values ({meterRead.AccountId}, {ConvertDateTime(meterRead.MeterReadDateTime)}, '{meterRead.ReadValue}');", _con))
                {
                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();
                }
            }
            return true;
        }

        //TODO write test
        public DateTime GetMostRecentMeterRead(int accountId)
        {
            using (SqlConnection _con = new SqlConnection(GetConnectionString()))
            {
                string queryStatement = $"SELECT TOP 1 * FROM dbo.MeterRead WHERE AccountId={accountId} ORDER BY DateTimeStamp DESC";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    DataTable tempTable = new DataTable("TempTable");

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(tempTable);
                    _con.Close();
                    if (tempTable.Rows.Count == 0)
                        return DateTime.MinValue;

                    return (DateTime)tempTable.Rows[0]["DateTimeStamp"];
                }
            }
        }

        //TODO Write test
        public bool CheckIfEntryExists(MeterRead meterRead)
        {

            using (SqlConnection _con = new SqlConnection(GetConnectionString()))
            {
                string queryStatement = $"SELECT * FROM dbo.MeterRead WHERE AccountId = {meterRead.AccountId} AND DateTimeStamp = {ConvertDateTime(meterRead.MeterReadDateTime)} AND MeterRead = '{meterRead.ReadValue}'";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
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
    }
}
