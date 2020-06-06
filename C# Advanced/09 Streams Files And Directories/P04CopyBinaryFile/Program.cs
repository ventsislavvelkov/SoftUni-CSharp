using System;
using System.IO;

namespace P04CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFile = @"..\..\..\files\car.jpg";
            var outputFile = @"..\..\..\files\outputImage.jpg";

            using (var streamReadFile = new FileStream(sourceFile, FileMode.Open))
            {
                var binaryReader = new BinaryReader(streamReadFile);

                using (var streamCreateFile = new FileStream(outputFile, FileMode.Create))
                {
                    var binaryWriter = new BinaryWriter(streamCreateFile);

                    while (true)
                    {
                        var buffer = new byte[4096];

                        var size = binaryReader.Read(buffer, 0, buffer.Length);

                        if (size <= 0)
                        {
                            break;
                        }

                        binaryWriter.Write(buffer, 0, size);

                        if (size < 4096)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
