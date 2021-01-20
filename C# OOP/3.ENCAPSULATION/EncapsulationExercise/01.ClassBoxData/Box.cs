using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            set
            {
                Validator.ValidateSide(value, "Length cannot be zero or negative.");
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            set
            {
                Validator.ValidateSide(value, "Width cannot be zero or negative.");
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            set
            {
                Validator.ValidateSide(value, "Height cannot be zero or negative.");
                this.height = value;
            }
        }

        public double GetSurfaceArea()
        {
            //2lw + 2lh + 2wh
            return (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
        }

        public double GetLateralSurfaceArea()
        {
            //2lh + 2wh
            return (2 * Length * Height) + (2 * Width * Height);
        }

        public double GetVolume()
        {
            //lwh
            return Length * Width * Height;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.GetSurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.GetVolume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
