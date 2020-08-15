namespace ChatApp.Core
{
    public class LoginResultApiModel
    {
        //Token used to stay authenticated
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
