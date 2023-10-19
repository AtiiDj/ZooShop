
using System;
using System.Collections.Generic;
using System.Text;
using ZooShop.Data;
using ZooShop.Models;

namespace Services
{
    public class ShopService
    {
        private AppDbContext context;
        public string AddTown(string name)
        {
            StringBuilder message = new StringBuilder();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(name))
            {
                message.AppendLine($"Invalid Town");
                isValid = false;
            }
            if (isValid)
            {
                Town t = new Town() { Name = name };
                using (context = new AppDbContext())
                {
                    context.Add(t);
                    context.SaveChanges();
                    message.AppendLine($"{nameof(Town)} {name} is added");
                }
            }
            return message.ToString().TrimEnd();
        }
        public Shop GetShopById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid Shop id!");
            }
            Shop shop = this.context.Shops.Find(id);
            return shop;
        }
        public string DeleteShopById(int id)
        {
            Shop shop = GetShopById(id);
            if (shop == null)
            {
                return $"Animal not found!";
            }
            context.Shops.Remove(shop);
            context.SaveChanges();
            return "Animal is suspended!";
        }
        public string AddShop(string name,int townId)
        {
            StringBuilder msg = new StringBuilder();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(name))
            {
                msg.AppendLine($"Invalid {nameof(name)}!");
                isValid = false;
            }
           
            
            using (context = new AppDbContext())
            {
                if (isValid)
                {
                    Shop p = new Shop()
                    {
                        Name = name,
                       TownId=townId
                    };
                    this.context.Shops.Add(p);
                    this.context.SaveChanges();
                    msg.AppendLine($"New Shop - {name} is added ");
                }
                return msg.ToString().TrimEnd();
            }
        }

    }
}
