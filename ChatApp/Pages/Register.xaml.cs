using ChatApp.Core;

namespace ChatApp
{

    public partial class Register : BasePage<RegisterViewModel>
    {
        public Register() : base()
        {
            InitializeComponent();

        }

        public Register(RegisterViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();

        }

    }
}
