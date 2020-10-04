using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    public class Engine
    {
        public int Power { get; set; }
        public int Speed { get; set; }
        public Engine()
        {

        }
        public Engine(int power, int speed)
        {
            this.Power = power;
            this.Speed = speed;
        }

    }
}
