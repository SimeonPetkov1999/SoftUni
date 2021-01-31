using System;

namespace _01.Stealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters(typeof(Hacker).ToString());
            Console.WriteLine(result);
        }
    }
}
