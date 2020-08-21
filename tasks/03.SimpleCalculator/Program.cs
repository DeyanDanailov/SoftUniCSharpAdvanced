using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var myStack = new Stack<string>(input.Reverse());
            
            while (myStack.Count>1)
            {
               
                int firstNumber = int.Parse(myStack.Pop());
                string sign = myStack.Pop();
                int secondnNumber = int.Parse(myStack.Pop());
                var tempResult = sign switch
                {
                    "+" => (firstNumber + secondnNumber),
                    "-" => (firstNumber - secondnNumber),
                    _ => 0
                };
                myStack.Push(tempResult.ToString());
            }
            
            Console.WriteLine(myStack.Pop());
        }
    }
}
