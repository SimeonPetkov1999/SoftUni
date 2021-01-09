using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var strArr = ArrayCreator.Create(5, "pesho");
            var strAInt = ArrayCreator.Create(5, 15);
            var strADouble = ArrayCreator.Create(5, 1.5);
            var strADecimal = ArrayCreator.Create(5, 1.5m);
        }
    }
}
