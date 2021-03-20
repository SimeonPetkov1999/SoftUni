using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BulletsPetBarrelPistol = 10;
        private const int TotalBulletsPistol = 100;
        public Pistol(string name) 
            : base(name, BulletsPetBarrelPistol, TotalBulletsPistol)
        {
            base.BulletsShot = 1;
        }
    }
}
