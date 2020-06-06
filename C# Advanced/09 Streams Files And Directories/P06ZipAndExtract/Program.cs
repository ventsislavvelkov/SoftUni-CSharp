using System;
using System.IO.Compression;

namespace P06ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @"..\..\..\files\images";
            string zipPath = @"..\..\..\files\result.zip";
            string extractPath = @"..\..\..\files\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true);

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
