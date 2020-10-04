using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Car car = new Car();
            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;
            //car.Drive(2000);

            //Console.WriteLine(car.WhoAmI());

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //var secondCar = new Car(make, model, year);
            //var thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            //var tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3)
            //};
            //var engine = new Engine(560, 6300);
            //var car = new Car("Alfa Romeo", "156", 2004, 60, 5.5, engine, tires);

            var tires = new List<Tire[]>();
            CollectTires(tires);
            var engines = new List<Engine>();
            CollectEngines(engines);
            var cars = new List<Car>();
            CollectCars(cars, engines, tires);
            cars = cars.Where(c => c.Year >= 2017).Where(c => c.Engine.HorsePower > 330).ToList();
            var specialCars = new List<Car>();
            FindSpecialCars(cars, specialCars);
            PrintCars(specialCars);
        }

        public static void PrintCars(List<Car> specialCars)
        {
            foreach (var specialCar in specialCars)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Make: {specialCar.Make}");
                sb.AppendLine($"Model: {specialCar.Model}");
                sb.AppendLine($"Year: {specialCar.Year}");
                sb.AppendLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                sb.AppendLine($"FuelQuantity: {specialCar.FuelQuantity}");
                Console.WriteLine(sb.ToString());
            }
        }

        public static void FindSpecialCars(List<Car> cars, List<Car> specialCars)
        {
            
            foreach (var car in cars)
            {
                var sumOfTires = 0.0;
                foreach (var tire in car.Tires)
                {
                    sumOfTires += tire.Pressure;
                }
                if (sumOfTires >= 9 && sumOfTires <= 10)
                {
                    car.Drive(20.0);
                    specialCars.Add(car);                   
                }
                
            }
        }

        public static void CollectTires(List<Tire[]> tires)
        {
            var command = Console.ReadLine();
            while (command != "No more tires")
            {
                var info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var currentTires = new Tire[4];
                var counter = 0;
                for (int i = 0; i < info.Length; i =i+2)
                {
                    currentTires[counter] = new Tire(int.Parse(info[i]), double.Parse(info[i+1]));
                    counter++;
                }
                tires.Add(currentTires);

                command = Console.ReadLine();
            }
        }
        public static void CollectEngines(List<Engine> engines)
        {
            var command = Console.ReadLine();
            while (command != "Engines done")
            {
                var info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var currentEngine = new Engine(int.Parse(info[0]), double.Parse(info[1]));
                engines.Add(currentEngine);

                command = Console.ReadLine();
            }
        }
        public static void CollectCars(List<Car> cars, List<Engine> engines, List<Tire[]> tires)
        {
            var command = Console.ReadLine();
            while (command != "Show special")
            {
                var info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var currentCar = new Car(info[0], 
                    info[1], 
                    int.Parse(info[2]), 
                    double.Parse(info[3]), 
                    double.Parse(info[4]), 
                    engines[int.Parse(info[5])], 
                    tires[int.Parse(info[6])]);
                cars.Add(currentCar);

                command = Console.ReadLine();
            }
        }
    }
}
