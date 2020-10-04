using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.CarSalesman
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string model)
        {
            this.Model = model;
            this.Engine = new Engine();
            this.Weight = "n/a";
            this.Color = "n/a";
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public Car GetCar(string input, HashSet<Engine> engines)
        {
            var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var car = new Car(args[0]);
            foreach (var eng in engines)
            {
                if (eng.Model == args[1])
                {
                    car.Engine = eng;
                }
            }
            if (args.Length == 3)
            {
                int weight;
                if (int.TryParse(args[2], out weight))
                {
                    car.Weight = args[2];
                }
                else
                {
                    car.Color = args[2];
                }
            }
            else if (args.Length == 4)
            {
                car.Weight = args[2];
                car.Color = args[3];

            }
            return car;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:")
            .AppendLine($"  {this.Engine}")
            .AppendLine($"  Weight: {this.Weight}")
            .Append($"  Color: {this.Color}");
            return sb.ToString().TrimEnd();
        }
    }
}
