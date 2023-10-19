using ConsoleAppZooShop.Controller;
using Services;
using System;
using System.Text;

namespace ConsoleAppZooShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Commands();
                Console.Write("Enter command: ");
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "0":
                        return;
                    case "1":
                        new AnimalController();
                        break;
                    case "2":
                        new ClientController();
                        break;

                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }
        public static void Commands()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Art life menu:");
            sb.AppendLine($"\t0: Back");
            sb.AppendLine($"\t1: Animals");
            sb.AppendLine($"\t2: Clients");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
