namespace CarManagement.Core.Requests
{
    public class UpdateUserRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string UserImage { get; set; }
    }
}