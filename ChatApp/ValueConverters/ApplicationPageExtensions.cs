using ChatApp.Core;
using ChatApp.Core.DataModels;
using ChatApp.ValueConverters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatApp
{


    public static class ApplicationPageExtensions
    {
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            switch (page)
            {
                case ApplicationPage.Login:
                    return new Login(viewModel as LoginViewModel);

                case ApplicationPage.Register:
                    return new Register(viewModel as RegisterViewModel);

                case ApplicationPage.Chat:
                    return new Chat(viewModel as ChatMessageListViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            if (page is Chat)
                return ApplicationPage.Chat;

            if (page is Login)
                return ApplicationPage.Login;

            if (page is Register)
                return ApplicationPage.Register;

            Debugger.Break();
            return default(ApplicationPage);
        }

    }
}
