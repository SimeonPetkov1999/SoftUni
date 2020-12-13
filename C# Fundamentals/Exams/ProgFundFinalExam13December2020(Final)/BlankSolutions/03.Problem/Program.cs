using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> users = new Dictionary<string, User>();

            int capacity = int.Parse(Console.ReadLine());

            string[] commandArgs = Console.ReadLine().Split("=");

            while (commandArgs[0] != "Statistics")
            {
                string command = commandArgs[0];
                if (command == "Add")
                {
                    string username = commandArgs[1];
                    int sent = int.Parse(commandArgs[2]);
                    int recieved = int.Parse(commandArgs[3]);
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new User(sent, recieved));
                    }
                }
                else if (command == "Message")
                {
                    string sender = commandArgs[1];
                    string reciever = commandArgs[2];
                    if (users.ContainsKey(sender) && users.ContainsKey(reciever))
                    {
                        users[sender].sent++;
                        users[reciever].recieved++;
                        if (users[sender].recieved + users[sender].sent >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            users.Remove(sender);
                        }
                        if (users[reciever].recieved + users[reciever].sent >= capacity)
                        {
                            Console.WriteLine($"{reciever} reached the capacity!");
                            users.Remove(reciever);
                        }
                    }
                }
                else if (command == "Empty")
                {
                    string username = commandArgs[1];
                    if (username == "All")
                    {
                        users.Clear();
                    }
                    else if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                }
                commandArgs = Console.ReadLine().Split("=");
            }

            foreach (var item in users)
            {
                item.Value.count = item.Value.recieved + item.Value.sent;
            }

            Console.WriteLine($"Users count: {users.Count}");
            foreach (var item in users.OrderByDescending(n => n.Value.recieved).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value.count}");
            }
        }
    }

    class User
    {
        public User(int mesagesSent,int mesagesRecieved)
        {
            sent = mesagesSent;
            recieved = mesagesRecieved;
            count = 0;
        }
        public int sent { get; set; }
        public int recieved { get; set; }
        public int count { get; set; }
    }
}
