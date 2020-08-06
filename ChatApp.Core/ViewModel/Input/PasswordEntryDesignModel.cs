using System;
using System.Windows.Input;

namespace ChatApp.Core
{
    /// <summary>
    /// View model for any string editing entry
    /// </summary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        public static PasswordEntryViewModel Instance => new PasswordEntryViewModel();

        public PasswordEntryDesignModel()
        {
        }
    }
}
