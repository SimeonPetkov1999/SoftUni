using _05.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations.Models
{
    class Robot : IID
    {
        public Robot(string model,string id)
        {
            this.Model = model;
            this.ID = id;
        }

        public string Model { get; private set; }
        public string ID { get; private set; }
    }
}
