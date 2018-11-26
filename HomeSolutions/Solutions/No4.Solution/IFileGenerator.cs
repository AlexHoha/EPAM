using System;
namespace Solutions
{
    public interface IFileGenerator
    {
        string WorkingDirectory
        {
            get;set;
        }

        string FileExtension
        {
            get;set;
        }
    }
}
