using System;

namespace _01OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string neededBook = Console.ReadLine();
            string book = Console.ReadLine();
            int numberOfBooks = 0;
            bool bookFound = false; 

            while (book!="No More Books")
            {
                if (book==neededBook)
                {
                    Console.WriteLine($"You checked {numberOfBooks} books and found it.");
                    bookFound = true;
                    break;
                }
                numberOfBooks++;
                book = Console.ReadLine();
            }

            if (!bookFound)
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {numberOfBooks} books.");

            }
        }
    }
}
