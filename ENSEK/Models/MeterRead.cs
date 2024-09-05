using ENSEK.Interfaces;
using System.Text.RegularExpressions;

namespace ENSEK.Models
{
    public class MeterRead : iMeterRead
    {
        public MeterRead(int accountId, string readValue, DateTime meterReadingDateTime) 
        {
            AccountId = accountId;
            ReadValue = readValue;
            MeterReadDateTime = meterReadingDateTime;
        }

        public MeterRead(string line)
        {
            string[] values = line.Split(",");
            AccountId = Int32.Parse(values[0]);
            MeterReadDateTime = DateTime.Parse(values[1]);
            ReadValue = values[2];
        }

        public int AccountId { get; set; }
        public string ReadValue { get; set; }
        public DateTime MeterReadDateTime { get; set; }
    }
}
