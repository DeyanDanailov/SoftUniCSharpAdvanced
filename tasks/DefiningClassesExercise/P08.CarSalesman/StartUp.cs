using System;
using System.Collections.Generic;

namespace P08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var engines = new HashSet<Engine>();
            var engine = new Engine();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                engines.Add(engine.GetEngine(input));
            }
            int m = int.Parse(Console.ReadLine());
            var cars = new HashSet<Car>();
            var car = new Car();
            for (int j = 0; j < m; j++)
            {
                var input = Console.ReadLine();
                cars.Add(car.GetCar(input, engines));
            }
            Console.WriteLine(String.Join(Environment.NewLine, cars));
        }
    }
}
