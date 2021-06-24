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
            PrintGuestsName();
            //  PrintWinner();
        }

        //Start writing your code here
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();
        private static Regex rgx = new Regex("[^a-zA-Z]");

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

            while (string.IsNullOrEmpty(user))
            {
                Console.WriteLine("Please enter a name:");
                user = Rgx(user);
            }

            return user;
        }

        private static void GetUserInfo()
        {
            string name;
            string otherGuest;
            string prompt = "Please enter your name:";
            string query = "Do you want to add another name?";

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

        //private static GetRaffleNumber(Dictionary<int, string> people)
        //{
        //    int randomTicket;

        //    foreach (KeyValuePair<int, string> ticket in guests)
        //    {

        //    }
        //}




        /*
                static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
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

                } */
    }
}
