using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Client> UpdateCli(int clientId, Client newClient)
        {
            var clientDB = await dbSet.Where(c => c.Id == clientId)
                .SingleOrDefaultAsync();

            if(clientDB == null)
            {
                throw new ArgumentException("Cadastro");
            }

            clientDB.Update(newClient);
            await context.SaveChangesAsync();
            return clientDB;
        }
    }
}
