using BoB.MS.Domain.Model;
using BoB.MS.Repository.Repositories;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoB.MS.Repository.Model;

namespace BoB.MS.Domain
{
    public interface IClientService
    {
        int SetupClient(ClientDto client);

        ClientDto Load(int id);
    }

    public class ClientService : IClientService
    {
        readonly IClientRepository repo;
        readonly IMapper mapper;

        public ClientService(IClientRepository _repo, IMapper _mapper)
        {
            this.repo = _repo;
            this.mapper = _mapper;
        }

        public int SetupClient(ClientDto client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            var clientData = this.mapper.Map<Client>(client);

            return repo.CreateClient(clientData);
        }

        public ClientDto Load(int id)
        {
            var clientInfo = repo.Load(id);
            return mapper.Map<ClientDto>(clientInfo);
        }
    }
}
