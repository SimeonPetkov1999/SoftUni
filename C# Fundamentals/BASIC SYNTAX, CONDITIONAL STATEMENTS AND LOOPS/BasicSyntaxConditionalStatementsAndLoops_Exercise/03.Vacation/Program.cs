using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0;

            switch (dayOfWeek)
            {
                case "Friday":
                    switch (typeOfGroup)
                    {
                        case"Students":
                            price = 8.45;
                            break;
                        case "Business":
                            price = 10.90;
                            break;
                        case "Regular":
                            price = 15;
                            break;
                    }
                    break;
                case "Saturday":
                    switch (typeOfGroup)
                    {
                        case "Students":
                            price = 9.80;
                            break;
                        case "Business":
                            price = 15.60;
                            break;
                        case "Regular":
                            price = 20;
                            break;
                    }
                    break;
                case "Sunday":
                    switch (typeOfGroup)
                    {
                        case "Students":
                            price = 10.46;
                            break;
                        case "Business":
                            price = 16;
                            break;
                        case "Regular":
                            price = 22.50;
                            break;
                    }
                    break;
            }

            if (typeOfGroup=="Business" && numberOfPeople>=100)
            {
                numberOfPeople -= 10;
            }

            double totalPrice = numberOfPeople * price;

            if (typeOfGroup=="Students" && numberOfPeople>=30)
            {
                totalPrice *= 0.85;
            }

            else if (typeOfGroup=="Regular"&& (numberOfPeople>=10&&numberOfPeople<=20))
            {
                totalPrice *= 0.95;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
