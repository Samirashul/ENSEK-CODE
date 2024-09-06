using ENSEK.DataAdapters;
using ENSEK.Interfaces;
using ENSEK.Models;
using System.Text.RegularExpressions;

namespace ENSEK.Validation
{
    public class MeterReadValidator : iMeterReadValidator
    {
        private readonly string _meterReadRegex = "^[0-9]{1,5}$";

        public bool IsMostRecentMeterRead(MeterRead meterRead)
        {
            MeterReadDataAdapter adapter = new MeterReadDataAdapter();
            return (DateTime.Compare(meterRead.MeterReadDateTime, adapter.GetMostRecentMeterRead(meterRead.AccountId)) > 0);
        }

        public bool IsReadValueCorrectFormat(MeterRead meterRead)
        {
            return Regex.Match(meterRead.ReadValue, _meterReadRegex).Success;
        }

        public bool IsMeterReadUnique(MeterRead meterRead)
        {
            MeterReadDataAdapter adapter = new MeterReadDataAdapter();
            return !adapter.CheckIfEntryExists(meterRead);
        }

        public bool HasAssosciatedAccount(MeterRead meterRead)
        {
            MeterReadDataAdapter adapter = new MeterReadDataAdapter();
            return adapter.CheckIfFieldExists("Account", "AccountId", meterRead.AccountId.ToString());
        }

        public bool IsValid(MeterRead meterRead)
        {
            return IsMeterReadUnique(meterRead) && HasAssosciatedAccount(meterRead) && IsReadValueCorrectFormat(meterRead);
        }
    }
}
