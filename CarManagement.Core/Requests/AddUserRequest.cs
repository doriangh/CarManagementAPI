namespace CarManagement.Core.Requests
{
    public class AddUserRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserImage { get; set; }
    }
}