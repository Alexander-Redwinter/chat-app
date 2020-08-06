using ChatApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatApp.IoC
{
    public class UIManager : IUIManager
    {
        public Task ShowMessage(MessageBoxViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }
    }
}
