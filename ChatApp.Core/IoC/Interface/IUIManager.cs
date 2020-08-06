using ChatApp.Core;
using System.Threading.Tasks;

namespace ChatApp
{
    public interface IUIManager
    {
        Task ShowMessage(MessageBoxViewModel viewModel);
    }
}
