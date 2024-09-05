using ENSEK.DataAdapters;
using ENSEK.FileReaders;
using ENSEK.Interfaces;
using ENSEK.Models;
using ENSEK.Validation;

namespace ENSEK.FileHandlers
{
    public class AccountFileHandler : iAccountFileHandler
    {
        public string HandleFile(string fileName)
        {
            AccountFileReader reader = new AccountFileReader();
            AccountDataAdapter adapter = new AccountDataAdapter();
            AccountValidator validator = new AccountValidator();

            int successes = 0;
            int failures = 0;

            foreach (Account account in reader.ReadFile(fileName))
            {
                if (validator.IsValid(account))
                {  
                    adapter.InsertAccount(account);
                    successes++; 
                }
                else failures++;
            }

            return $"A total of {successes + failures} accounts were processed. {successes} were processed successfully, {failures} failed to be validated.";
        }

        public async Task<string> HandleFile(IFormFile file)
        {
            var filePath = Path.GetTempFileName();

            // Creates the file at filePath and copies the contents
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return HandleFile(filePath);
        }
    }
}
