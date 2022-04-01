using BoB.MS.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoB.MS.Repository.Repositories
{
    public interface IClientRepository
    {
        int CreateClient(Client client);
        Client Load(int id);
    }

    public class ClientRepository
         : IClientRepository
    {
        public int CreateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            using (var context = new ClientContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
                return client.Id;
            }
        }

        public Client Load(int id)
        {
            using (var context = new ClientContext())
            {
                return context.Clients.First(s => s.Id == id);
            }
        }
    }
}
