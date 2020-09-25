using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using var stream = new FileStream("copyMe.png", FileMode.OpenOrCreate);
            using var copied = new FileStream("copy.png", FileMode.OpenOrCreate);
            stream.CopyTo(copied);
           
        }
    }
}
