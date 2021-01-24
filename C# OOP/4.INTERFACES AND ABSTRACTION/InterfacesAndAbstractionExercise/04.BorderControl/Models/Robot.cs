using _04.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    class Robot : IInhabitant
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
