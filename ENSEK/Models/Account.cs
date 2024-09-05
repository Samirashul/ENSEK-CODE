using ENSEK.Interfaces;
using System.Text.RegularExpressions;

namespace ENSEK.Models
{
    public class Account : iAccount
    {

        public Account(int accountId, string firstName, string surName) 
        {
            AccountId = accountId;
            FirstName = firstName;
            SurName = surName;
        }

        public Account(string line)
        {
            string[] values = line.Split(",");
            AccountId = Int32.Parse(values[0]);
            FirstName = values[1];
            SurName = values[2];
        }

        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
}
