using ChatApp.Core.Security;
using System;
using System.Net.Http.Headers;
using System.Security;
using System.Windows.Input;

namespace ChatApp.Core
{
    /// <summary>
    /// View model for password editing entry
    /// </summary>
    public class PasswordEntryViewModel : BaseViewModel
    {
        public string Label { get; set; }

        public string Display { get; set; }

        public string CurrentPasswordHintText { get; set; }
        public string NewPasswordHintText { get; set; }
        public string ConfirmPasswordHintText { get; set; }

        /// <summary>
        /// Saved value
        /// </summary>
        public SecureString OriginalPassword { get; set; }


        /// <summary>
        /// New value
        /// </summary>
        public SecureString EditedPassword { get; set; }

        public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// Flag to indicate that current text is in edit mode
        /// </summary>
        public bool IsEditing { get; set; }

        /// <summary>
        /// Puts the text in edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Cancels edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Saves the value, goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        public PasswordEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);

            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";

        }

        private void Save()
        {
            //TODO actual password checking with remote web server 
            var storedPassword = "test";

            if (storedPassword != OriginalPassword.Unsecure())
            {
                Container.UI.ShowMessage(new MessageBoxViewModel
                {
                    Title = "Error",
                    Message = "Invalid password"
                });
                return;
            }

            if (EditedPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                Container.UI.ShowMessage(new MessageBoxViewModel
                {
                    Title = "Error",
                    Message = "Password mismatch"
                });
                return;
            }

            if (EditedPassword.Unsecure().Length == 0)
            {
                Container.UI.ShowMessage(new MessageBoxViewModel
                {
                    Title = "Error",
                    Message = "You must enter a password"
                });

                return;
            }

            OriginalPassword = new SecureString();

            foreach (var c in EditedPassword.Unsecure().ToCharArray())
                OriginalPassword.AppendChar(c);

            IsEditing = false;
        }

        private void Cancel()
        {
            IsEditing = false;
        }

        private void Edit()
        {
            EditedPassword = new SecureString();
            ConfirmPassword = new SecureString();

            IsEditing = true;
        }
    }
}
