using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //ZipFile.CreateFromDirectory(@"C:\Users\DeyanDanailov\SoftUniCSharpAdvanced\SoftUniCSharpAdvanced\tasks\06.ZipAndExtract\bin\Debug\netcoreapp3\copyMe.png",
            //    @"D:\zipped.zip");
            //ZipFile.ExtractToDirectory(@"D:\zipped.zip", @"D:\Danailov\computer science\II semester");

            var zipFile = @"..\..\..\Myzip.zip";
            var file = @"..\..\..\copyMe.png";

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }
    }
}
