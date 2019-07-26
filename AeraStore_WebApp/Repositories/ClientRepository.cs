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
        public ClientRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
