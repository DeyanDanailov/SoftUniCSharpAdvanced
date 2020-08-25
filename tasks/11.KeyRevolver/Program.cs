using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrel = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var startBulletsCount = bullets.Count;
            var locks = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var intelligence = int.Parse(Console.ReadLine());
            var earnedMoney = 0;

            while (true)
            {
                if (gunBarrel>bullets.Count)
                {
                    gunBarrel = bullets.Count;
                }
                for (int i = 0; i < gunBarrel; i++)
                {
                    int bullet = bullets.Pop();
                    int currentLock = locks.Peek();
                    if (bullet > currentLock)
                    {
                        Console.WriteLine("Ping!");
                        if (!bullets.Any())
                        {
                            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                            return;
                        }
                    }
                    else
                    {
                        locks.Dequeue();
                        Console.WriteLine("Bang!");
                        if (!locks.Any())
                        {
                            if (bullets.Any())
                            {
                                Console.WriteLine("Reloading!");
                            }
                            earnedMoney = intelligence - (startBulletsCount - bullets.Count) * bulletPrice;
                            Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
                            return;
                        }
                        if (!bullets.Any())
                        {
                            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                            return;
                        }
                    }
                }
                
                Console.WriteLine("Reloading!");
            }
        }
    }
}
