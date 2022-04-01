using BoB.MS.Domain;
using BoB.MS.Domain.Model;
using BoB.MS.Service;
using Grpc.Core;

namespace BoB.MS.Service.Services
{
    public class ClientsService : Clients.ClientsBase
    {
        private readonly ILogger<ClientsService> _logger;
        private readonly IClientService service;
        public ClientsService(ILogger<ClientsService> logger, IClientService _service)
        {
            _logger = logger;
            service = _service;
        }

        public override Task<ClientInfo> GetClient(ClientId id, ServerCallContext context)
        {
            var client = this.service.Load(id.Value);
            return Task.FromResult(new ClientInfo
            {
                Name = client.Name,
                Id = client.Id
            });
        }

        public override Task<ClientId> CreateClient(ClientInfo request, ServerCallContext context)
        {
            var id = this.service.SetupClient(new ClientDto() { Name = request.Name });
            return Task.FromResult(new ClientId
            {
                Value = id
            });
        }
    }
}