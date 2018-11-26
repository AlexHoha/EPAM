using System;
using System.IO;
namespace Solutions
{
    /// <summary>
    /// Вынести общую логику в отдельный класс
    /// </summary>
    public abstract class AbstractFileGenerator
    {
        protected abstract byte[] GenerateFileContent(int contentLength);

        protected void WriteBytesToFile(string WorkingDirectory,string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }

        public void GenerateFiles(int filesCount, int contentLength, string FileExtension, string WorkingDirectory)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{FileExtension}";

                WriteBytesToFile(WorkingDirectory, generatedFileName, generatedFileContent);
            }
        }
    }
}
