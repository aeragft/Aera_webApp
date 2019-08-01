using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Repositories
{
    public class ClientRepository : BaseRepository<Client> , IClientRepository
    {
        private readonly IClientRepository clientRepository;

        public ClientRepository(ApplicationContext context, IClientRepository clientRepository) : base(context)
        {
            this.clientRepository = clientRepository;
        }

        public Client UpdateCli(int clientId, Client newClient)
        {
            throw new NotImplementedException();
        }
    }
}
