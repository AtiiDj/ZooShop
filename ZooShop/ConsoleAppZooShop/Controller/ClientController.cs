﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppZooShop.Controller
{
    public class ClientController
    {
        private static ClientService cs;
        public ClientController()
        {
            cs = new ClientService();
            Run();
        }
        private void Run()
        {

            while (true)
            {
                try
                {
                    Console.Clear();
                    Commands();
                    Console.Write("> Enter command:");
                    string cmd = Console.ReadLine();
                    switch (cmd)
                    {
                        case "0":
                            return;
                        case "1":
                            PrintClientsInfo();
                            break;
                        case "2":
                            AddNewClient();
                            break;
                        default:
                            Console.WriteLine("Invalid command!");
                            WaitPressKey();

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    WaitPressKey();
                }
            }
        }
        public void PrintClientsInfo()
        {
            int currentPage = 1;
            int pageCount = cs.GetClientPagesCount();
            while (true)
            {
                Console.Clear();
                try
                {
                    string result = cs.GetAllClientsInfo(currentPage);
                    Console.WriteLine(result);
                    Console.WriteLine("Commands: 0:Back, 1:Previous page, 2:Next page ");
                    Console.Write("Enter command: ");
                    string cmd = Console.ReadLine();
                    switch (cmd)
                    {
                        case "0":
                            return;
                        case "1":
                            if (currentPage > 1) { currentPage--; }
                            break;
                        case "2":
                            if (currentPage < pageCount) { currentPage++; }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }
        public void AddNewClient()
        {
            Console.Write($"> Enter first name: ");
            string name = Console.ReadLine();
            Console.Write($"> Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write($"> Enter town: ");
            int town = int.Parse(Console.ReadLine());
           
            string result = cs.AddClient(name, lastName,town);
            Console.WriteLine(result);
            WaitPressKey();
        }
        public void GetExactClientInfo()
        {
            try
            {
                Console.Write($"> Enter client's id: ");
                int id = int.Parse(Console.ReadLine());
                string result = cs.GetClientInfoById(id);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            WaitPressKey();
        }
        private static void WaitPressKey()
        {
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
        }
        public void Commands()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Clients menu:");
            sb.AppendLine($"\t0: Back");
            sb.AppendLine($"\t1: Client list");
            sb.AppendLine($"\t2: Add new client");
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
