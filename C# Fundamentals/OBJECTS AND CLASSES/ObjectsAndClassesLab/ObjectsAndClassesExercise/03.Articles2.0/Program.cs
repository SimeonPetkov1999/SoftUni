using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Article> articels = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Article myArticle = new Article(input[0], input[1], input[2]);
                articels.Add(myArticle);
            }

            string finalCommand = Console.ReadLine();

            if (finalCommand=="title")
            {
               articels = articels.OrderBy(n=>n.Title).ToList();
            }

            else if (finalCommand == "content")
            {
                articels = articels.OrderBy(n => n.Content).ToList();
            }

            else if (finalCommand =="author")
            {
                articels = articels.OrderBy(n => n.Author).ToList();
            }

            foreach (var item in articels)
            {
                item.MyToString();
            }
            
        }

        class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title;
            public string Content;
            public string Author;

            public void MyToString() 
            {
                Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
            }
        }
    }
}
