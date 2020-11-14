using System;
using System.Collections.Generic;

namespace _04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> translator = new Dictionary<string, char>()
            {
                { ".-"   , 'a'} ,
                { "-..." , 'b'} ,
                { "-.-." , 'c'} ,
                { "-.."  , 'd'} ,
                { "."    , 'e'} ,
                { "..-." , 'f'} ,
                { "--."  , 'g'} ,
                { "...." , 'h'} ,
                { ".."   , 'i'} ,
                { ".---" , 'j'} ,
                { "-.-"  , 'k'} ,
                { ".-.." , 'l'} ,
                { "--"   , 'm'} ,
                { "-."   , 'n'} ,
                { "---"  , 'o'} ,
                { ".--." , 'p'} ,
                { "--.-" , 'q'} ,
                { ".-."  , 'r'} ,
                { "..."  , 's'} ,
                { "-"    , 't'} ,
                { "..-"  , 'u'} ,
                { "...-" , 'v'} ,
                { ".--"  , 'w'} ,
                { "-..-" , 'x'} ,
                { "-.--" , 'y'} ,
                { "--.." , 'z'},
                { "|"    , ' '}
            };

            string[] morse = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string word = string.Empty;
            for (int i = 0; i < morse.Length; i++)
            {
                char letter = translator[morse[i]];
                word += letter;
            }

            Console.WriteLine(word.ToUpper());


        }
    }
}
