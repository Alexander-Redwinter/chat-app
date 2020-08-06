namespace ChatApp.Core
{
    public class MessageBoxViewModel : BaseDialogViewModel
    {
        public string Message { get; set; }
        public string OkText { get; set; } = "OK";
    }
}
