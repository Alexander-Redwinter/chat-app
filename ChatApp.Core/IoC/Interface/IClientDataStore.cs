using System.Threading.Tasks;

namespace ChatApp.Core
{
    public interface IClientDataStore
    {
        Task<bool> HasCredentialsAsync();

        Task EnsureDataStoreAsync();

        Task<LoginCredentialsDataModel> GetLoginCredentialsAsync();

        Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials);

    }
}
