using ENSEK.Interfaces;
using ENSEK.Models;

namespace ENSEK.FileReaders
{
    public class AccountFileReader : FileReader, iAccountFileReader
    {
        new public List<Account> ReadFile(string filename)
        {
            List<Account> accounts = new List<Account>();

            List<string> lines = File.ReadLines(filename).ToList();

            lines.RemoveAt(0);

            foreach (string s in lines)
                accounts.Add(new Account(s));

            return accounts;
        }
    }
}
