using ENSEK.Models;

namespace ENSEK.Interfaces
{
    public interface iAccountFileReader : iFileReader
    {
        new public List<Account> ReadFile(string filename);
    }
}
