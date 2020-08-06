using ChatApp.Core.DataModels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApp.Core
{
    public class RegisterViewModel : BaseViewModel
    {

        public string Email { get; set; }

        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }


        public bool IsRegisterRunning { get; set; }


        public RegisterViewModel()
        {
            LoginCommand = new RelayParametrizedCommand(async (parameter) => await Login(parameter));

            RegisterCommand = new RelayCommand(async () => await Register());


        }

        public async Task Login(object parameter)
        {
            Container.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);

            await Task.Delay(1);

        }

        public async Task Register()
        {
            await RunCommand(() => this.IsRegisterRunning, async () =>
            {
                //(parameter as IHavePassword).SecurePassword.Unsecure();
                //TODO actual register
                Container.Get<ApplicationViewModel>().IsGifHidden = false;
                await Task.Delay(5000);
                Container.Get<ApplicationViewModel>().IsGifHidden = true;

            });
        }

    }
}
