using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split();

                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);
                    if (index > array.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        int[] backArray = array.Take(index + 1).ToArray();
                        int[] frontArray = array.Skip(index + 1).ToArray();
                        array = frontArray.Concat(backArray).ToArray();
                    }
                }

                if (command[0] == "max")
                {
                    int indexMaxEven = int.MinValue;
                    int maxEven = int.MinValue;
                    if (command[1] == "even")
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 == 0)
                            {
                                if (array[i] >= maxEven)
                                {
                                    maxEven = array[i];
                                    indexMaxEven = i;
                                }
                            }
                        }
                        if (indexMaxEven == int.MinValue)
                        {
                            Console.WriteLine("No Matches");
                        }

                        else
                        {
                            Console.WriteLine(indexMaxEven);
                        }
                    }

                    else if (command[1] == "odd")
                    {
                        int indexMaxOdd = int.MinValue;
                        int maxOdd = int.MinValue;
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 != 0)
                            {
                                if (array[i] >= maxOdd)
                                {
                                    maxOdd = array[i];
                                    indexMaxOdd = i;
                                }
                            }
                        }
                        if (indexMaxOdd == int.MinValue)
                        {
                            Console.WriteLine("No Matches");
                        }
                        else
                        {
                            Console.WriteLine(indexMaxOdd);
                        }
                    }
                }
                if (command[0] == "min")
                {
                    int indexMinEven = int.MaxValue;
                    int minEven = int.MaxValue;
                    int minOdd = int.MaxValue;
                    if (command[1] == "even")
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 == 0)
                            {
                                if (array[i] <= minEven)
                                {
                                    minEven = array[i];
                                    indexMinEven = i;
                                }
                            }
                        }
                        if (indexMinEven == int.MaxValue)
                        {
                            Console.WriteLine("No matches");
                        }

                        else
                        {
                            Console.WriteLine(indexMinEven);
                        }
                    }

                    else if (command[1] == "odd")
                    {
                        int indexMinOdd = int.MaxValue;
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 != 0)
                            {
                                if (array[i] <= minOdd)
                                {
                                    minOdd = array[i];
                                    indexMinOdd = i;
                                }

                            }
                        }
                        if (indexMinOdd == int.MaxValue)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(indexMinOdd);
                        }
                    }
                }

                if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);
                    string[] result = new string[count];
                    int indexString = 0;
                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        int currentEvens = 0;
                        int currentOdds = 0;
                        if (command[2] == "even")
                        {

                            for (int i = 0; i < array.Length; i++)
                            {
                                if (currentEvens >= count)
                                {
                                    break;
                                }
                                if (array[i] % 2 == 0)
                                {
                                    result[indexString++] = array[i].ToString();
                                    currentEvens++;
                                }
                            }
                            if (currentEvens == 0)
                            {
                                Console.WriteLine("[]");
                            }
                            else
                            {
                                Console.WriteLine("[" + string.Join(", ", result) + "]");
                            }
                        }


                        if (command[2] == "odd")
                        {
                            indexString = 0;
                            result = new string[count];
                            for (int i = 0; i < array.Length; i++)
                            {
                                if (currentOdds >= count)
                                {
                                    break;
                                }
                                if (array[i] % 2 != 0)
                                {
                                    result[indexString++] = array[i].ToString();
                                    currentOdds++;
                                }
                            }
                        }
                        if (currentOdds == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else
                        {
                            Console.WriteLine("[" + string.Join(", ", result) + "]");
                        }
                    }
                }


                if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);
                    string[] result = new string[count];
                    int indexString = 0;
                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        int currentEvens = 0;
                        int currentOdds = 0;
                        if (command[2] == "even")
                        {

                            for (int i = array.Length - 1; i >= 0; i--)
                            {
                                if (currentEvens >= count)
                                {
                                    break;
                                }
                                if (array[i] % 2 == 0)
                                {
                                    result[indexString++] = array[i].ToString();
                                    currentEvens++;
                                }
                            }
                            if (currentEvens == 0)
                            {
                                Console.WriteLine("[]");
                            }
                            else
                            {
                                Console.WriteLine("[" + string.Join(", ", result) + "]");
                            }
                        }


                        else if (command[2] == "odd")
                        {
                            indexString = 0;
                            result = new string[count];
                            for (int i = array.Length - 1; i >= 0; i--)
                            {
                                if (currentOdds >= count)
                                {
                                    break;
                                }
                                if (array[i] % 2 != 0)
                                {
                                    result[indexString++] = array[i].ToString();
                                    currentOdds++;
                                }
                            }
                            if (currentOdds == 0)
                            {
                                Console.WriteLine("[]");
                            }
                            else
                            {
                                Array.Reverse(result);
                                Console.WriteLine("[" + string.Join(", ", result) + "]");
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }
    }
}