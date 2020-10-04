using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
        public Engine()
        {

        }
        public Engine(string model, string power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }
        public Engine GetEngine(string input)
        {
            var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var engine = new Engine(args[0], args[1]);
            if (args.Length == 3)
            {
                int displacement;
                if (int.TryParse(args[2], out displacement))
                {
                    engine.Displacement = args[2];
                }
                else
                {
                    engine.Efficiency = args[2];
                }
            }
            else if (args.Length == 4)
            {
                engine.Displacement = args[2];
                engine.Efficiency = args[3];
            }
            return engine;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine($"    Displacement: {this.Displacement}");
            sb.Append($"    Efficiency: {this.Efficiency}");
            return sb.ToString();
        }
    }
}
