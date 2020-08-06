using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace ChatApp.Core.ViewModel
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}
