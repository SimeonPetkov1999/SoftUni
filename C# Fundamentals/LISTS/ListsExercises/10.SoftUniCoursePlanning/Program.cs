using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();
            while (input != "course start")
            {
                string[] command = input.Split(':');
                if (command[0] == "Add")
                {
                    string lessonTitle = command[1];

                    if (!Exist(schedule, lessonTitle))
                    {
                        schedule.Add(lessonTitle);
                    }
                }
                else if (command[0] == "Insert")
                {
                    string lessonTitle = command[1];
                    int index = int.Parse(command[2]);

                    if (!Exist(schedule, lessonTitle))
                    {
                        schedule.Insert(index, lessonTitle);
                    }
                }
                else if (command[0] == "Remove")
                {
                    string lesonTittle = command[1];
                    if (Exist(schedule, lesonTittle))
                    {
                        schedule.Remove(lesonTittle);
                        schedule.Remove($"{lesonTittle}-Exercise");
                    }
                }
                else if (command[0] == "Swap")
                {
                    string lesonTittleOne = command[1];
                    string lesonTittleTwo = command[2];
                    int indexOne = -1;
                    int indexTwo = -1;
                    if (Exist(schedule, lesonTittleOne) && Exist(schedule, lesonTittleTwo))
                    {
                        for (int i = 0; i < schedule.Count; i++)
                        {
                            if (schedule[i] == lesonTittleOne)
                            {
                                indexOne = i;
                            }

                            else if (schedule[i] == lesonTittleTwo)
                            {
                                indexTwo = i;
                            }
                        }
                        string temp = schedule[indexOne];
                        schedule[indexOne] = schedule[indexTwo];
                        schedule[indexTwo] = temp;

                        if (Exist(schedule, $"{lesonTittleOne}-Exercise"))
                        {
                            schedule.RemoveAt(indexOne + 1);
                            schedule.Insert(indexTwo + 1, $"{lesonTittleOne}-Exercise");
                        }

                        if (Exist(schedule, $"{lesonTittleTwo}-Exercise"))
                        {
                            schedule.RemoveAt(indexTwo + 1);
                            schedule.Insert(indexOne + 1, $"{lesonTittleTwo}-Exercise");
                        }
                    }
                }

                else if (command[0] == "Exercise")
                {
                    string lesonTittle = command[1];
                    int indexLesson = -1;
                    if (Exist(schedule, lesonTittle))
                    {
                        if (!Exist(schedule, $"{lesonTittle}-Exercise"))
                        {
                            for (int i = 0; i < schedule.Count; i++)
                            {
                                if (schedule[i] == lesonTittle)
                                {
                                    indexLesson = i;
                                }
                            }
                            schedule.Insert(indexLesson + 1, $"{lesonTittle}-Exercise");
                        }
                    }
                    else
                    {
                        schedule.Add(lesonTittle);
                        schedule.Add($"{lesonTittle}-Exercise");
                    }
                }
                input = Console.ReadLine();
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
        static bool Exist(List<string> schedule, string lesson)
        {
            for (int i = 0; i < schedule.Count; i++)
            {
                if (lesson == schedule[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
