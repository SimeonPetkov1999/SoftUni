using System;
using System.Text;
using System.Linq;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = Console.ReadLine();
            //
            //path = path.Remove(0, path.LastIndexOf('\\')+1);
            //string name = path.Substring(0, path.IndexOf('.'));
            //string extension = path.Substring(path.IndexOf('.')+1);
            //
            //Console.WriteLine($"File name: {name}");
            //Console.WriteLine($"File extension: {extension}");

            string[] path = Console.ReadLine()
                    .Split(new string[] { "\\", "." }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"File name: {path[path.Length-2]}");
            Console.WriteLine($"File extension: {path[path.Length - 1]}");
        }
    }
}
