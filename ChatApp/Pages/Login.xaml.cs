using System.Security;
using System.Windows.Controls;
using ChatApp.Core;
using ChatApp.Core.ViewModel;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : BasePage<LoginViewModel>, IHavePassword
    {
        public Login() : base()
        {   
            InitializeComponent();

        }

        public Login(LoginViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();

        }
        public SecureString SecurePassword => PasswordBox.SecurePassword;
    }
}
