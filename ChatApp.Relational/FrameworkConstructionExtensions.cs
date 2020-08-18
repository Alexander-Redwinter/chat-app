using ChatApp.Core;
using Cornerstone;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Relational
{
    /// <summary>
    /// For use with Cornerstone framework's <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        public static FrameworkConstruction UseClientDataStore(this FrameworkConstruction construction)
        {

            construction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                //TODO use configuration json
                options.UseSqlite("Data Source=ChatApp.db");
            });

            construction.Services.AddScoped<IClientDataStore>(provider => new ClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            return construction;
        }

    }
}
