using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppZooShop.Controller
{
    public class AnimalController
    {
       
        private static AnimalService cs;
        public AnimalController()
        {
          
            cs = new AnimalService();
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
                            PrintAnimalsInfo();
                            break;
                        case "2":
                            AddNewAnimal();
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
        public void PrintAnimalsInfo()
        {
            int currentPage = 1;
            int pageCount = cs.GetAnimalPagesCount();
            while (true)
            {
                try
                {


                    Console.Clear();
                    string result = cs.GetAllAnimalsInfo(currentPage);
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
        public void AddNewAnimal()
        {
            try
            {
                Console.Write($"> Enter the id of the animal: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write($"> Enter animal name: ");
                string name = Console.ReadLine();

                Console.Write($"> Enter type : ");
                string type = Console.ReadLine();

                Console.Write($"> Enter colour: ");
                string colour = Console.ReadLine();

                Console.Write($"> Enter town id: ");
                int town = int.Parse(Console.ReadLine());

                Console.Write($"> Enter client id: ");
                int client = int.Parse(Console.ReadLine());


                string result = cs.AddAnimal(name,type,colour,town,client);
                Console.WriteLine(result);
                int projectId = cs.GetAnimalIdByName(name);
              
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
            sb.AppendLine($"Animals menu:");
            sb.AppendLine($"\t0: Back");
            sb.AppendLine($"\t1: Animals list");
            sb.AppendLine($"\t2: Add new animal");
          
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
