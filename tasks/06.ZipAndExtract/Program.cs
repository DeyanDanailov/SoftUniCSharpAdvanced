using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\DeyanDanailov\SoftUniCSharpAdvanced\SoftUniCSharpAdvanced\tasks\06.ZipAndExtract\bin\Debug\netcoreapp3\copyMe.png",
                @"D:\zipped.zip");
            ZipFile.ExtractToDirectory(@"D:\zipped.zip", @"D:\Danailov\computer science\II semester");
        }
    }
}
