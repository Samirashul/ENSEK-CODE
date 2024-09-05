using ENSEK.Interfaces;
using ENSEK.Models;

namespace ENSEK.FileReaders
{
    public class MeterReadFileReader : FileReader, iMeterReadFileReader
    {

        new public List<MeterRead> ReadFile(string filename)
        { 
            List<MeterRead> meterReads = new List<MeterRead>();

            foreach (string s in File.ReadLines(filename))
                meterReads.Add(new MeterRead(s));

            return meterReads;
        }
    }
}
