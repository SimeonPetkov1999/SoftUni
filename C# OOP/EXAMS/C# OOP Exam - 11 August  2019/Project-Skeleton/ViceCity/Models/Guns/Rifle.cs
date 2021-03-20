using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BulletsPerBarrelRifle = 50;
        private const int TotalBulletsRifle = 500;
        public Rifle(string name) 
            : base(name, BulletsPerBarrelRifle, TotalBulletsRifle)
        {
            base.BulletsShot = 5;
        }
    }
}
