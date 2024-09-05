using ENSEK.Interfaces;

namespace ENSEK.FileReaders
{
    public class FileReader : iFileReader
    {
        public List<string> ReadFile(string filename)
        { 
            return File.ReadAllLines(filename).ToList();
        }
    }
}
