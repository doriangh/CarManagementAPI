namespace CarManagement.Core.Requests
{
    public class VerifySessionRequest
    {
        public int UserId { get; set; }
        public string Key { get; set; }
    }
}