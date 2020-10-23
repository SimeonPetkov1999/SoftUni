using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int n = int.Parse(Console.ReadLine());

            Article myArticle = new Article();
            myArticle.Author = input[2];
            myArticle.Content = input[1];
            myArticle.Title = input[0];


            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "Edit")
                {
                    myArticle.edit(command[1]);
                }

                else if (command[0]=="ChangeAuthor")
                {
                    myArticle.changeAuthor(command[1]);
                }

                else if (command[0]=="Rename")
                {
                    myArticle.rename(command[1]);
                }
            }

            Console.WriteLine($"{myArticle.Title} - {myArticle.Content}: {myArticle.Author}");

        }

        class Article
        {
            public string Title;
            public string Content;
            public string Author;

            public void edit(string content) 
            {
                this.Content = content;
            }
            public void changeAuthor(string autnor)
            {
                this.Author = autnor;
            }
            public void rename(string title)
            {
                this.Title = title;
            }
        }
    }
}
