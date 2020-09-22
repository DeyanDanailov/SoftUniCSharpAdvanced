using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("text.txt");
            var evenCounter = 0;
            var line = reader.ReadLine();
            while (true)
            {
                if (line == null)
                {
                    break;
                }
                if (evenCounter%2 ==0)
                {
                    var strArr = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    strArr = strArr.Reverse().ToArray();
                    for(var i =0; i< strArr.Length; i++)
                    {
                        strArr[i]  = strArr[i].Replace('-', '@');
                        strArr[i]  = strArr[i].Replace(',', '@');
                        strArr[i]  = strArr[i].Replace('.', '@');
                        strArr[i]  = strArr[i].Replace('!', '@');
                        strArr[i]  = strArr[i].Replace('?', '@');
                  
                    }
                    Console.WriteLine(String.Join(" ", strArr));
                }
                evenCounter++;
                line = reader.ReadLine();
            }
        }
    }
}
