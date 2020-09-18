using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SliceText
{
    class Program
    {
        static void Main(string[] args)
        {
            using var stream = new FileStream("Text.txt", FileMode.OpenOrCreate);
            Console.WriteLine(stream.Length);
            var parts = 4;
            var piece  = (int)Math.Ceiling(stream.Length/(decimal)parts);
            var buffer = new byte[piece];
            for (int i = 1; i <= parts; i++)
            {
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead < buffer.Length)
                {
                    buffer = buffer.Take(bytesRead).ToArray();
                }
                using var currentPartStream = new FileStream($"Part{i}.txt", FileMode.OpenOrCreate);
                currentPartStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
