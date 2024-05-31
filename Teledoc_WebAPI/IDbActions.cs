using Teledoc_WebAPI.Tables;

namespace Teledoc_WebAPI
{
    public interface IDbActions
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int id);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        Client DeleteClient(int id);
        Founder GetFounder(int id);
        void CreateFounder(Founder founder);
        void UpdateFounder(Founder founder);
        Founder DeleteFounder(int id);
    }
}
