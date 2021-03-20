using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;
        private int initialBulletsPerBarrel;
        public Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
            this.initialBulletsPerBarrel = bulletsPerBarrel;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Name cannot be null or a white space!");
                }
                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Bullets cannot be below zero!");
                }
                this.bulletsPerBarrel = value;//?
               
            }
        }


        public int TotalBullets 
        {
            get => this.totalBullets;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }
                this.totalBullets = value;
            }
        }

        public bool CanFire => totalBullets > 0;

        public virtual int BulletsShot { get; protected set; }
        public int Fire()
        {
            if (this.BulletsPerBarrel <= 0)//?
            {
                this.BulletsPerBarrel = this.initialBulletsPerBarrel;
                this.TotalBullets -= this.initialBulletsPerBarrel;
            }

            this.BulletsPerBarrel -= this.BulletsShot;
            return this.BulletsShot;
        }
    }
}
