using System;
using System.Linq;

namespace _01.ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var createCommand = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> list = null;
            if (createCommand.Length == 1)
            {
                 list = new ListyIterator<string>();
            }
            else
            {
                list = new ListyIterator<string>(createCommand.Skip(1).ToList());
            }

            var command = Console.ReadLine();
            while (command!="END")
            {
                if (command=="Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (command=="Print")
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
                else if (command=="HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }

                command = Console.ReadLine();
            }

          }
    }
}
