using Data.ZooShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZooShop.Models;

public class ClientService
    {

    private AppDbContext context;
    public int GetClientPagesCount(int count = 10)
    {
        using (context = new AppDbContext())
        {
            return (int)Math.Ceiling(context.Clients.Count() / (double)count);
        }
    }
    public string DeleteClientById(int id)
    {
        using (context = new AppDbContext())
        {
            Client client = context.Clients.Find(id);
            if (client == null)
            {
                return $"{nameof(Client)} not found!";
            }
            context.Clients.Remove(client);
            context.SaveChanges();
            return $"{nameof(Client)} {client.FirstName} {client.LastName}- this client is deleted";
        }
    }
    public string GetAllClientsInfo(int page = 1, int count = 10)
    {
        StringBuilder msg = new StringBuilder();
        string firstRow = $"| {"Id",-4} | {"First name",-12} | {"Last name",-12} |";

        string line = $"|{new string('-', firstRow.Length - 2)}| ";

        using (context = new AppDbContext())
        {
            List<Client> clients = context.Clients.Skip((page - 1) * count).Take(count).ToList();
            msg.AppendLine(firstRow);
            msg.AppendLine(line);
            foreach (var c in clients)
            {
                string info = $"| {c.Id,-4} | {c.FirstName,-12} | {c.LastName,-12}  |";
                msg.AppendLine(info);
                msg.AppendLine(line);
            }
            int pageCount = (int)Math.Ceiling(context.Clients.Count() / (decimal)count);
            msg.AppendLine($"Page: {page} / {pageCount}");
        }

        return msg.ToString().TrimEnd();

    }
    public Client GetClientById(int id)
    {
        using (context = new AppDbContext())
        {
            return context.Clients.FirstOrDefault(x => x.Id == id);
        }
    }
    public string GetClientInfoById(int id)
    {
        Client client = null;
        using (context = new AppDbContext())
        {
            client = context.Clients.Find(id);

            if (client != null)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendLine($"{nameof(Client)} info: ");
                msg.AppendLine($"\tId: {client.Id}");
                msg.AppendLine($"\tFirst name: {client.FirstName}");
                msg.AppendLine($"\tLast name: {client.LastName}");
                string townName = client.Towns.Name;
                msg.AppendLine($"\tAddress: {townName}");
                return msg.ToString().TrimEnd();
            }
            else
            {
                return $"{nameof(Client)} not found!";
            }
        }
    }
    public string AddClient(string firstName, string lastName)
    {
        StringBuilder msg = new StringBuilder();
        bool isValid = true;
        if (string.IsNullOrWhiteSpace(firstName))
        {
            msg.AppendLine($"Invalid {nameof(firstName)}!");
            isValid = false;
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            msg.AppendLine($"Invalid {nameof(lastName)}!");
            isValid = false;
        }
        using (context = new AppDbContext())
        {
            if (isValid)
            {
                Client p = new Client()
                {
                    FirstName = firstName,
                    LastName = lastName,
                };
                this.context.Clients.Add(p);
                this.context.SaveChanges();
                msg.AppendLine($"New Client - {firstName} {lastName} is added ");
            }
            return msg.ToString().TrimEnd();
        }
    }

}

