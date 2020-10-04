using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
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
