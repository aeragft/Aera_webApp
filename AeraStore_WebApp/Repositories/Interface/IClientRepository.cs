using AeraStore_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Repositories.Interface
{
    public interface IClientRepository
    {
        Client UpdateCli(int clientId, Client newClient);
    }
}
