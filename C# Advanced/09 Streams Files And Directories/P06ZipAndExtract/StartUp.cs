using System;
using System.IO.Compression;

namespace P06ZipAndExtract
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var startPath = @"..\..\..\files\car";
            var zipPath = @"..\..\..\files\result.zip";
            var extractPath = @"..\..\..\files\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true);

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
