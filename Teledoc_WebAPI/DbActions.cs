using Teledoc_WebAPI.Migrations;
using Teledoc_WebAPI.Tables;

namespace Teledoc_WebAPI
{
    public class DbActions : IDbActions
    {
        private TeledocDBContext context;

        public DbActions(TeledocDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Client> GetClients()
        {
            return context.Clients;
        }

        public Client GetClient(int id)
        {
            return context.Clients.Find(id);
        }

        public void CreateClient(Client client)
        {
            client.DateOfAddition = DateTime.Now.ToUniversalTime();
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            Client currentClient = GetClient(client.Id);
            currentClient.INN = client.INN;
            currentClient.ClientName = client.ClientName;
            currentClient.Type = client.Type;
            currentClient.DateOfUpdate = DateTime.Now.ToUniversalTime();

            context.Clients.Update(currentClient);
            context.SaveChanges();
        }

        public Client DeleteClient(int id)
        {
            Client client = GetClient(id);

            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }

            return client;
        }

        public Founder GetFounder(int id)
        {
            return context.Founders.Find(id);
        }

        public void CreateFounder(Founder founder)
        {
            founder.DateOfAddition = DateTime.Now.ToUniversalTime();
            context.Founders.Add(founder);
            context.SaveChanges();
        }

        public Founder DeleteFounder(int id)
        {
            Founder founder = GetFounder(id);

            if (founder != null)
            {
                context.Founders.Remove(founder);
                context.SaveChanges();
            }

            return founder;
        }

        public void UpdateFounder(Founder founder)
        {
            Founder currentFounder = GetFounder(founder.Id);
            currentFounder.INN = founder.INN;
            currentFounder.Name = founder.Name;
            currentFounder.DateOfUpdate = DateTime.Now.ToUniversalTime();

            context.Founders.Update(currentFounder);
            context.SaveChanges();
        }
    }
}
