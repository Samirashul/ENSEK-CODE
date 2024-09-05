using ENSEK.Models;
using System.Data.SqlClient;

namespace ENSEK.DataAdapters
{
    public class AccountDataAdapter : BaseAdapter
    {
        public bool InsertAccount(Account account)
        {
            using (SqlConnection _con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand _cmd = new SqlCommand($"INSERT INTO dbo.Account values ('{account.AccountId.ToString()}', '{account.FirstName}', '{account.SurName}');", _con))
                {
                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();
                }
            }
            return true;
        }
    }
}
