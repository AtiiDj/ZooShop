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
            SeedAnimal();
            SeedClients();
            SeedShops();
            SeedTowns();
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
                t.Add("Blagoevgrad");
                t.Add("Burgas");
                t.Add("Bansko");
                t.Add("London");
                t.Add("Rome");
                t.Add("Paris");
                t.Add("Helzinki");
                t.Add("Otawa");
                t.Add("New York");
                t.Add("Washington");
                t.Add("Pernik");
                t.Add("Dubai");
                t.Add("Ciro");
                t.Add("Buenos Aires");
                t.Add("Montevideo");
                t.Add("Monaco");
                t.Add("Normandy");
                t.Add("Berlin");
                t.Add("Vienna");
                t.Add("Munchen");
                t.Add("Limasol");
                t.Add("Madrid");
                t.Add("Lisbon");
                t.Add("Barcelona");
                t.Add("Porto");

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
          
            Console.WriteLine(cService.AddClient("Serkan", "Bolat"));
            Console.WriteLine(cService.AddClient("Eda", "Yildiz"));
        }
        public static void SeedShops()
        {

            Console.WriteLine(sService.AddShop("Happy animal"));
            Console.WriteLine(sService.AddShop("Smiling animal"));

        }
        public static void SeedAnimal()
        {
            Console.WriteLine(aService.AddAnimal("Konn","dog","black"));
            Console.WriteLine(aService.AddAnimal("Steve", "koala", "White"));
        }
        }
}
