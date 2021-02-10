using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int MuscleCarCubicCentimeters = 5000;
        private const int MuscleCarMinHorsePower = 400;
        private const int MuscleCarMaxHorsePower = 600;
        public MuscleCar(string model, int horsePower)
           : base(model, horsePower, MuscleCarCubicCentimeters, MuscleCarMinHorsePower, MuscleCarMaxHorsePower)
        {}
    }
}
