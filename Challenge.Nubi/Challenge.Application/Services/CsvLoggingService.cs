using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Challenge.Domain.Options;
using System;

namespace Challenge.Application.Services
{
    public interface ICsvLoggingService
    {
        Task WriteLine(string data);
    }

    public class CsvLoggingService : ICsvLoggingService
    {
        private readonly string folderName;
        private readonly string fileName;

        public CsvLoggingService(IOptions<CsvLoggingOptions> options)
        {
            folderName = options.Value.FolderName;
            fileName = options.Value.FileName;
        }

        public async Task WriteLine(string data)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            fullPath = Path.Combine(fullPath, fileName);

            using var writer = File.AppendText(fullPath);
            await writer.WriteLineAsync(data);

            writer.Dispose();
        }
    }
}
