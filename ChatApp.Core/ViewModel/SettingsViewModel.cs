using ChatApp.Core.DataModels;
using System;
using System.Windows.Input;

namespace ChatApp.Core
{

    public class SettingsViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand OpenCommand { get; set; }

        public ICommand LogoutCommand { get; set; }
        public ICommand ClearUserDataCommand { get; set; }


        public TextEntryViewModel Name { get; set; }
        public TextEntryViewModel Username { get; set; }
        public PasswordEntryViewModel Password { get; set; }
        public TextEntryViewModel Email { get; set; }

        public string LogoutButtonText { get; set; }
        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);

            //TODO Localize
            LogoutButtonText = "Logout";

            //TODO remove this design time data
            Name = new TextEntryViewModel()
            {
                Label = "Name",
                OriginalText = "Alexander Redwinter"
            };
            Username = new TextEntryViewModel()
            {
                Label = "Username",
                OriginalText = "Redwinter"
            };
            Password = new PasswordEntryViewModel()
            {
                Label = "Password",
                Display = "***"
            };
            Email = new TextEntryViewModel()
            {
                Label = "Email",
                OriginalText = "qwerty@qwerty.com"
            };
        }

        private void Open()
        {
            Container.Application.IsSettingsMenuExpanded = true;
        }
        private void Close()
        {
            Container.Application.IsSettingsMenuExpanded = false;
        }
        private void Logout()
        {
            //TODO confirm logout
            //TODO logout
            //TODO clean info about user



            ClearUserData();

            Container.Application.GoToPage(ApplicationPage.Login);
        }
        private void ClearUserData()
        {
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }
    }
}
