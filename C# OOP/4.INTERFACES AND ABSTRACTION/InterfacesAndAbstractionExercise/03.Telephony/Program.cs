﻿using _03.Telephony.Models;
using System;
using System.Text.RegularExpressions;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var smartphone = new SmartPhone();
            var stationaryPhone = new StationaryPhone();

            var numbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var urls = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbers)
            {
                if (Regex.IsMatch(number,@"\D"))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (number.Length==10)
                {
                    Console.WriteLine(smartphone.Call(number));
                }
                else
                {
                    Console.WriteLine(stationaryPhone.Call(number));
                }
            }

            foreach (var url in urls)
            {
                if (Regex.IsMatch(url, @"\d"))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                Console.WriteLine(smartphone.Browse(url));
            }

               
        }
    }
}
