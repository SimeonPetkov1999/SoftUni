using System;
using System.Linq;

namespace _02.Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var createCommand = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> list = new ListyIterator<string>(createCommand.Skip(1).ToArray());
            

            var command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (command=="PrintAll")
                {
                    foreach (var item in list)
                    {
                        Console.Write(item+" ");
                    }
                    Console.WriteLine();
                }
                command = Console.ReadLine();
            }
        }
    }
}
