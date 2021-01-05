using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Engine
    {
        public double EngineSpeed { get; set; }
        public double EnginePower { get; set; }

        public Engine(double speed, double power) 
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }
    }
}
