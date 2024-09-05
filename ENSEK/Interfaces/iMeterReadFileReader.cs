using ENSEK.Models;

namespace ENSEK.Interfaces
{
    public interface iMeterReadFileReader : iFileReader
    {
        new public List<MeterRead> ReadFile(string filename);
    }
}
