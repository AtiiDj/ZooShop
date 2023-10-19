using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZooShop.Models;
using ZooShop.Data;

namespace Services
{
    public class AnimalService
    {
        private AppDbContext context;
        public string AddAnimal(string name,  string type, string colour,int shopId,int clientId)
        {
            StringBuilder msg = new StringBuilder();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(name))
            {
                msg.AppendLine($"Invalid {nameof(name)}!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                msg.AppendLine($"Invalid {nameof(type)}!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(colour))
            {
                msg.AppendLine($"Invalid {nameof(colour)}!");
                isValid = false;
            }
            using (context = new AppDbContext())
            {
                if (isValid)
                {
                    Animal p = new Animal()
                    {
                        Name = name,
                        Type = type,
                        Colour = colour,
                        ShopId = shopId,
                        ClientId = clientId

                    };
                    this.context.Animals.Add(p);
                    this.context.SaveChanges();
                    msg.AppendLine($"New Animal - {name} is added ");
                }
                return msg.ToString().TrimEnd();
            }
        }

        public string DeleteAnimalById(int id)
        {
            Animal animal = GetAnimalById(id);
            if (animal == null)
            {
                return $"Animal not found!";
            }
            context.Animals.Remove(animal);
            context.SaveChanges();
            return "Animal is removed!";
        }
        public Animal GetAnimalById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid Animal id!");
            }
            Animal animal = this.context.Animals.Find(id);
            return animal;
        }
        public int GetAnimalIdByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid animal name...");
            }
            using (context = new AppDbContext())
            {
                Animal p = this.context.Animals.FirstOrDefault(x => x.Name == name);
                return p.Id;
            }
        }
        public string GetAnimalInfo(int id)
        {
            Animal a = null;
            using (context = new AppDbContext())
            {
                a = context.Animals.Find(id);
            }
            if (a != null)
            {
                StringBuilder message = new StringBuilder();
                message.AppendLine($"{nameof(a)} info: ");
                message.AppendLine($"\tId: {a.Id}");
                message.AppendLine($"\tName: {a.Name}");
                message.AppendLine($"\tType: {a.Type}");
                message.AppendLine($"\tColour: {a.Colour}");
            }
            
                return $"{nameof(Animal)} not found!";
            
        }
        public string GetAllAnimalsInfo(int page = 1, int count = 10)
        {
            StringBuilder msg = new StringBuilder();
            string firstRow = $"| {"Id",-4} | {"Name",-25} | {"Type Id: ",-9} | {"Colour",-12} | ";

            string line = $"|{new string('-', firstRow.Length - 2)}|";

            using (context = new AppDbContext())
            {
                List<Animal> projects = context.Animals.Skip((page - 1) * count).Take(count).ToList();
                msg.AppendLine(firstRow);
                msg.AppendLine(line);
                foreach (var c in projects)
                {
                    string info = $"| {c.Id,-4} | {c.Name,-25} | {c.Type ,-9} | {c.Colour,-12} |";
                    msg.AppendLine(info);
                    msg.AppendLine(line);
                }
                int pageCount = (int)Math.Ceiling(context.Animals.Count() / (decimal)count);
                msg.AppendLine($"Page: {page} / {pageCount}");
            }

            return msg.ToString().TrimEnd();
        }
        public int GetAnimalPagesCount(int count = 10)
        {
            using (context = new AppDbContext())
            {
                return (int)Math.Ceiling(context.Clients.Count() / (double)count);
            }
        }
    }
}
