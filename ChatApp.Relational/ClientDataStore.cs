using ChatApp.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Relational
{
    public class ClientDataStore : IClientDataStore
    {


        protected ClientDataStoreDbContext _dbContext;

        public ClientDataStore(ClientDataStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> HasCredentialsAsync()
        {
            return await GetLoginCredentialsAsync() != null;

        }

        public async Task EnsureDataStoreAsync()
        {
            await _dbContext.Database.EnsureCreatedAsync();
        }

        public Task<LoginCredentialsDataModel> GetLoginCredentialsAsync()
        {
            return Task.FromResult(_dbContext.LoginCredentials.FirstOrDefault());
        }

        public async Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials)
        {
            _dbContext.LoginCredentials.RemoveRange(_dbContext.LoginCredentials);

            _dbContext.LoginCredentials.Add(loginCredentials);

            await _dbContext.SaveChangesAsync();
        
        }



    }
}
