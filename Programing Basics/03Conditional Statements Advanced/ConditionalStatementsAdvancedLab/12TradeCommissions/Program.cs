using System;

namespace _12TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            bool check = true;

            switch (city)
            {
                case "Sofia":
                    if (sales>=0 && sales <=500)
                    {
                        sales = sales * 0.05;
                    }
                    else if (sales >500 && sales <=1000)
                    {
                        sales = sales * 0.07;
                    }

                    else if (sales >1000&& sales <=10000)
                    {
                        sales = sales * 0.08;
                    }

                    else if (sales>10000)
                    {
                        sales = sales * 0.12;
                    }
                    else
                    {
                        check = false;
                    }
                    break;
                
                case "Varna":
                    if (sales >= 0 && sales <= 500)
                    {
                        sales = sales * 0.045;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        sales = sales * 0.075;
                    }

                    else if (sales > 1000 && sales <= 10000)
                    {
                        sales = sales * 0.10;
                    }

                    else if (sales > 10000)
                    {
                        sales = sales * 0.13;
                    }
                    else
                    {
                        check = false;
                    }
                    break;
                
                case "Plovdiv":
                    if (sales >= 0 && sales <= 500)
                    {
                        sales = sales * 0.055;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        sales = sales * 0.08;
                    }

                    else if (sales > 1000 && sales <= 10000)
                    {
                        sales = sales * 0.12;
                    }

                    else if (sales > 10000)
                    {
                        sales = sales * 0.145;
                    }
                    else
                    {
                        check = false;
                    }
                    break;
                default:
                    check = false;
                    break;
            }

            if (check)
            {
                Console.WriteLine($"{sales:f2}");
            }

            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
