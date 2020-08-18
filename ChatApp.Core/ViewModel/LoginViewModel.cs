using ChatApp.Core.DataModels;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Cornerstone;
using ChatApp.Core.ViewModel;
using ChatApp.Core.Security;

namespace ChatApp.Core
{
    public class LoginViewModel : BaseViewModel
    {

        public string Email { get; set; }

        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }


        public bool IsLoginRunning { get; set; }


        public LoginViewModel()
        {
            LoginCommand = new RelayParametrizedCommand(async (parameter) => await Login(parameter));

            RegisterCommand = new RelayCommand(async () => await Register());


        }

        public async Task Login(object parameter)
        {

            await RunCommand(() => this.IsLoginRunning, async () =>
            {
                Container.Get<ApplicationViewModel>().IsGifHidden = false;

                var result = await WebRequests.PostAsync<ApiResponse<LoginResultApiModel>>("http://localhost:5000/api/login", new LoginCredentialApiModel
                {
                    UsernameOrEmail = Email,
                    Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                });

                if (result == null || result.ServerResponse == null || !result.ServerResponse.Successful)
                {
                    //TODO Localize
                    var message = "Unknown error";
                    if (result?.ServerResponse != null)
                        message = result.ServerResponse.ErrorMessage;
                    else if (string.IsNullOrWhiteSpace(result?.RawServerResponse))
                        message = $"Unexpected response {result.RawServerResponse}";
                    else if (result != null)
                        message = $"Failed to communicate {result.StatusCode} {result.StatusDescription}";

                    await Container.UI.ShowMessage(new MessageBoxViewModel
                    {
                        //TODO Localize
                        Title = "Login Failed",
                        Message = message

                    }) ;

                    Container.Get<ApplicationViewModel>().IsGifHidden = true;
                    return;
                }


                var userData = result.ServerResponse.Response;

                await Container.ClientDataStore.SaveLoginCredentialsAsync(new LoginCredentialsDataModel
                {
                    Email = userData.Email,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    Username = userData.Username,
                    Token = userData.Token
                });

                Container.Settings.Load();

                Container.Get<ApplicationViewModel>().IsGifHidden = true;
                Container.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);

            });

        }

        public async Task Register()
        {

            Container.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }

    }
}
