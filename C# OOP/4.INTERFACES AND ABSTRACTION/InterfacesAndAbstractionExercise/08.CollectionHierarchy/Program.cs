using _08.CollectionHierarchy.Models;
using System;
using System.Text;

namespace _08.CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var addList = new AddCollection();
            var addRemoveList = new AddRemoveCollection();
            var myList = new MyList();

            var input = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var indesexAddList = new int[input.Length];
            var indesexAddRemoveList = new int[input.Length];
            var indesexMyList = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                indesexAddList[i] = addList.Add(input[i]);
                indesexAddRemoveList[i] = addRemoveList.Add(input[i]);
                indesexMyList[i] = myList.Add(input[i]);
            }

            var numberOfRemoveCommand = int.Parse(Console.ReadLine());
            var sbAddRemoveList = new StringBuilder();
            var sbMyList = new StringBuilder();
            
            for (int i = 0; i < numberOfRemoveCommand; i++)
            {
                sbAddRemoveList.Append($"{addRemoveList.Remove()} ");
                sbMyList.Append($"{myList.Remove()} ");
            }

            Console.WriteLine(string.Join(' ',indesexAddList));
            Console.WriteLine(string.Join(' ',indesexAddRemoveList));
            Console.WriteLine(string.Join(' ',indesexMyList));
            Console.WriteLine(sbAddRemoveList);
            Console.WriteLine(sbMyList);

        }
    }
}
