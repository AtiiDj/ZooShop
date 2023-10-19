using Services;
using System;
using System.Collections.Generic;

namespace ZooShop.Seeder
{
    public class Program
    {

        private static AnimalService aService = new AnimalService();
        private static ClientService cService = new ClientService();
        private static ShopService sService = new ShopService();
        public static void Main(string[] args)
        {
            SeedTowns();
            SeedClients();
            SeedShops();
            SeedAnimal();

        }
        public static void SeedTowns()
        {
            try
            {
                List<string> t = new List<string>();
                t.Add("Plovdiv");
                t.Add("Pazardzhik");
                t.Add("Sofia");
                t.Add("Varna");
                t.Add("Ruse");

                for (int i = 0; i < t.Count; i++)
                {
                    string name = t[i];
                    Console.WriteLine(sService.AddTown(name));
                }
            }
            catch (Exception)
            {

            }

        }
        public static void SeedClients()
        {

            Console.WriteLine(cService.AddClient("Serkan", "Bolat", 1));
            Console.WriteLine(cService.AddClient("Eda", "Yildiz", 2));
        }
        public static void SeedShops()
        {

            Console.WriteLine(sService.AddShop("Happy animal", 4));
            Console.WriteLine(sService.AddShop("Smiling animal", 3));

        }
        public static void SeedAnimal()
        {
            Console.WriteLine(aService.AddAnimal("Konn", "dog", "black", 1, 1));
            Console.WriteLine(aService.AddAnimal("Steve", "koala", "White", 2, 2));
        }
    }
}
