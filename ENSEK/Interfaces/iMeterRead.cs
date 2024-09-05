namespace ENSEK.Interfaces
{
    public interface iMeterRead
    {
        public int AccountId { get; set; }
        public string ReadValue { get; set; }
        public DateTime MeterReadDateTime { get; set; }
    }
}
