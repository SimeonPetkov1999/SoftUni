using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            while (input != "end")
            {
                var match = Regex.Match(input, @"^([A-Z][a-z'\s]+):([A-Z\s]+)$");
                if (match.Success)
                {
                    int key = match.Groups[1].Value.Length;
                    string encryptedArtist = string.Empty;
                    string encryptedSong = string.Empty;
                    foreach (var item in match.Groups[1].Value)
                    {
                        if (item == '\'' || item == ' ')
                        {
                            encryptedArtist += item;
                        }
                        else
                        {
                            if (item>=65 && item <=90)
                            {
                                if (item + key > 90)
                                {
                                    encryptedArtist += (char)((key - (91 - item)) + 97);
                                }
                                else
                                {
                                    encryptedArtist += (char)(key + item);
                                }
                            }
                            else if (item>=97 && item <=122)
                            {
                                if (item + key > 122)
                                {
                                    encryptedArtist += (char)((key - (123 - item)) + 97);
                                }
                                else
                                {
                                    encryptedArtist += (char)(key + item);
                                }
                            }
                        }
                    }
                    foreach (var item in match.Groups[2].Value)
                    {
                        if (item == '\'' || item == ' ')
                        {
                            encryptedSong += item;
                        }
                        else
                        {
                            if (item >= 65 && item <= 90)
                            {
                                if (item + key > 90)
                                {
                                    encryptedSong += (char)((key - (91 - item)) + 97);
                                }
                                else
                                {
                                    encryptedSong += (char)(key + item);
                                }
                            }
                            else if (item >= 97 && item <= 122)
                            {
                                if (item + key > 122)
                                {
                                    encryptedSong += (char)((key - (123 - item)) + 97);
                                }
                                else
                                {
                                    encryptedSong += (char)(key + item);
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Successful encryption: {encryptedArtist}@{encryptedSong.ToUpper()}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
