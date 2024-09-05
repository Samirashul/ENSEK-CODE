using ENSEK.Models;
using System.Diagnostics.Metrics;

namespace ENSEK.Interfaces
{
    public interface iMeterReadValidator
    {
        public bool IsMostRecentMeterRead(MeterRead meterRead);
        public bool IsReadValueCorrectFormat(MeterRead meterRead);
        public bool IsMeterReadUnique(MeterRead meterRead);
        public bool HasAssosciatedAccount(MeterRead meterRead);
        public bool IsValid(MeterRead meterRead);
    }
}
