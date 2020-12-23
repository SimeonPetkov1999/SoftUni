using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var sizeOfBarrel = int.Parse(Console.ReadLine());
            var bulletsStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locksQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var valueOfInteligence = int.Parse(Console.ReadLine());

            var bulletsUsed = 0;
            bool noMoreBullets = false;
            bool noMoreLocks = false;
            while (true)
            {
                var currentBullet = 0;
                var currentLock = 0;
                for (int i = 0; i < sizeOfBarrel; i++)
                {
                    if (bulletsStack.Any())
                    {
                        currentBullet = bulletsStack.Peek();
                    }
                    else
                    {
                        noMoreBullets = true;
                        break;
                    }
                    if (locksQueue.Any())
                    {
                        currentLock = locksQueue.Peek();
                    }
                    else
                    {
                        noMoreLocks = true;
                        break;
                    }
                    if (currentBullet > currentLock)
                    {
                        bulletsStack.Pop();
                        Console.WriteLine("Ping!");
                        bulletsUsed++;
                        if (!bulletsStack.Any())
                        {
                            noMoreBullets = true;
                            break;
                        }
                    }
                    else
                    {
                        bulletsStack.Pop();
                        Console.WriteLine("Bang!");
                        locksQueue.Dequeue();
                        bulletsUsed++;
                        if (!locksQueue.Any())
                        {
                            noMoreLocks = true;
                            break;
                        }
                    }
                }
                if (bulletsStack.Count == 0 && locksQueue.Count == 0)
                {
                    break;
                }
                if (noMoreBullets)
                {
                    break;
                }
                Console.WriteLine("Reloading!");
                if (noMoreLocks)
                {
                    break;
                }
            }
            if (noMoreLocks)
            {
                var totalMoney = valueOfInteligence - (bulletsUsed * bulletPrice);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${totalMoney}");
            }
            else if (noMoreBullets)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
        }
    }
}