using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    public class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }
        public Cargo()
        {

        }
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }
}
