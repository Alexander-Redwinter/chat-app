using ChatApp.Core.DataModels;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

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

                //(parameter as IHavePassword).SecurePassword.Unsecure();
                //TODO actual login
                Container.Settings.Name = new TextEntryViewModel() { Label = "Name", OriginalText = "Alexander Redwinter" };
                Container.Settings.Username = new TextEntryViewModel() { Label = "Username", OriginalText = "Redwinter" };
                Container.Settings.Password = new PasswordEntryViewModel() { Label = "Password", Display = "***" };
                Container.Settings.Email = new TextEntryViewModel() { Label = "Email", OriginalText = "querty@qwerty.com" };


                Container.Get<ApplicationViewModel>().IsGifHidden = false;
                await Task.Delay(500);
                Container.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);
                Container.Get<ApplicationViewModel>().IsGifHidden = true;

            });

        }

        public async Task Register()
        {

            Container.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }

    }
}
