using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
           
            var stack = new Stack<char>();
           
            bool isBalanced = true;
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == '(' || input[j] == '{' || input[j] == '[')
                {
                    stack.Push(input[j]);
                }
                else if(input[j] == ')' || input[j] == '}' || input[j] == ']')
                {
                    if (!stack.Any())
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    var current = stack.Pop();
                    if ((input[j] == ')' && current == '(') || (input[j] == '}' && current == '{') || (input[j] == ']' && current == '['))
                    {
                        isBalanced = true;
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                        
                }
                
            }            
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else if (isBalanced == false)
            {
                Console.WriteLine("NO");
            }
        }
    }
}
