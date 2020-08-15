namespace ChatApp.Core
{
    public class ApiResponse<T>
    {
        public bool Successful => ErrorMessage == null;

        public string ErrorMessage { get; set; }

        public T Response { get; set; }

    }
}
