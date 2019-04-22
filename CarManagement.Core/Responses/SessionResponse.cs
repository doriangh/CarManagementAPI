namespace CarManagement.Core.Responses
{
    public class SessionResponse : GenericResponse
    {
        public int UserId { get; set; }
        public string Key { get; set; }
    }
}