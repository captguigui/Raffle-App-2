using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            MultiLineAnimation();
            PrintGuestsName();
            PrintWinner();
        }

// private static variables to be accessed throughout the entire class (Added Regex for input validation)
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();
        private static Regex rgx = new Regex("[^a-zA-Z]");

// Created a Regex method to trim and make inputs lowercase
        private static string Rgx(string input)
        {
            string user = input.Trim();
            user = rgx.Replace(user, "").ToLower();
            return user;
        }

        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string user = Console.ReadLine();
            user = Rgx(user);

            while (string.IsNullOrEmpty(user) || guests.ContainsValue(user))
            {
                Console.WriteLine("Sorry, it looks like that name is either taken or invalid.\nPlease enter a name to try again:");
                user = Console.ReadLine();
                user = Rgx(user);
            }

            return user;
        }

        private static void GetUserInfo()
        {
            string name;
            string otherGuest;
            string prompt = "\nPlease enter a name:";
            string query = "\nDo you want to add another name?";

            do
            {
                name = GetUserInput(prompt);
                raffleNumber = GenerateRandomNumber(min, max);

                AddGuestsInRaffle(raffleNumber, name);

                otherGuest = GetUserInput(query);
            } while (otherGuest == "yes");
        }

        private static int GenerateRandomNumber(int min, int max)
        {
            int randomNum = _rdm.Next(min, max);
            return randomNum;
        }

        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guests.Add(raffleNumber, guest);
        }

        private static void PrintGuestsName()
        {
            Console.WriteLine("Guests and their ticket number:");
            foreach (KeyValuePair<int, string> guest in guests)
            {
                Console.WriteLine($"{guest.Value}: {guest.Key}");
            }
        }

        private static int GetRaffleNumber(Dictionary<int, string> people)
        {
            int index = _rdm.Next(guests.Count);
            int winnerNumber = guests.Keys.ElementAt(index);

            return winnerNumber;
        }

        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            string winnerName = guests[winnerNumber];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nThe Winner is: {winnerName}, with the winning ticket #{winnerNumber}!!\nPlease come forward to collect your prize!");
        }

// Animation provided by class, credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        static void MultiLineAnimation()
                {
                    var counter = 0;
                    for (int i = 0; i < 30; i++)
                    {
                        Console.Clear();

                        switch (counter % 4)
                        {
                            case 0:
                                {
                                    Console.WriteLine("         ╔════╤╤╤╤════╗");
                                    Console.WriteLine("         ║    │││ \\   ║");
                                    Console.WriteLine("         ║    │││  O  ║");
                                    Console.WriteLine("         ║    OOO     ║");
                                    break;
                                };
                            case 1:
                                {
                                    Console.WriteLine("         ╔════╤╤╤╤════╗");
                                    Console.WriteLine("         ║    ││││    ║");
                                    Console.WriteLine("         ║    ││││    ║");
                                    Console.WriteLine("         ║    OOOO    ║");
                                    break;
                                };
                            case 2:
                                {
                                    Console.WriteLine("         ╔════╤╤╤╤════╗");
                                    Console.WriteLine("         ║   / │││    ║");
                                    Console.WriteLine("         ║  O  │││    ║");
                                    Console.WriteLine("         ║     OOO    ║");
                                    break;
                                };
                            case 3:
                                {
                                    Console.WriteLine("         ╔════╤╤╤╤════╗");
                                    Console.WriteLine("         ║    ││││    ║");
                                    Console.WriteLine("         ║    ││││    ║");
                                    Console.WriteLine("         ║    OOOO    ║");
                                    break;
                                };
                        }

                        counter++;
                        Thread.Sleep(200);
                    }

                } 
    }
}
