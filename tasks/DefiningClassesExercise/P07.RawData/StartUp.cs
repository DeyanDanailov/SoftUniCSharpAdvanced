using System;
using System.Collections.Generic;

namespace P07.RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var car = new Car();
            var cars = new HashSet<Car>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var curentCar = car.CollectCarInfo(input);
                cars.Add(curentCar);
            }
            var cargoFilter = Console.ReadLine();
            car.PrintCarsDependingOnCargoFilter(cars, cargoFilter);
        }
    }
}
