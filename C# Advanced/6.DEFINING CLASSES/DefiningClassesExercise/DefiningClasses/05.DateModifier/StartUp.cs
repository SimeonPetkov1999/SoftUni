using System;

namespace _05.DateModifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {  
            var date1 = Console.ReadLine();
            var date2 = Console.ReadLine();
            var dateModifier = new DateModifier(date2,date1);
            Console.WriteLine(dateModifier.DaysDifference());
        }
    }
}
