using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    class Validator
    {
        public static void ValidateSide(double value, string message)
        {
            if (value <= 0)
            {
                throw new Exception(message);
            }
        }
    }
}
