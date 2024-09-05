using ENSEK.DataAdapters;
using ENSEK.FileReaders;
using ENSEK.Interfaces;
using ENSEK.Models;
using ENSEK.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENSEK.FileHandlers
{
    public class MeterReadFileHandler : iMeterReadFileHandler
    {

        public string HandleFile(string fileName)
        {
            MeterReadFileReader reader = new MeterReadFileReader();
            MeterReadValidator validator = new MeterReadValidator();
            MeterReadDataAdapter adapter = new MeterReadDataAdapter();

            int successes = 0;
            int failures = 0;

            foreach (MeterRead read in reader.ReadFile(fileName))
            {
                if (validator.IsValid(read))
                {
                    adapter.InsertMeterRead(read);
                    successes++;
                }
                else failures++;
            }

            return $"A total of {successes+failures} reads were processed. {successes} were processed successfully, {failures} failed to be validated.";
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
