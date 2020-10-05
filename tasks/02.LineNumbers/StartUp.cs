using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines(@"..\..\..\text.txt").ToArray();
            
            for (int i = 0; i < text.Length; i++)
            { 
                var letters = 0;
                var puncts = 0;
                foreach (var symbol in text[i])
                {
                    if (Char.IsLetter(symbol))
                    {
                        letters++;
                    }
                    if (char.IsPunctuation(symbol))
                    {
                        puncts++;
                    }
                }
                File.AppendAllText(@"..\..\..\result.txt", $"Line {i +1}: {text[i]} ({letters})({puncts})\n");
            }
        }
    }
}
