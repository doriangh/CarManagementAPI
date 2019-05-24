namespace CarManagement.Core.Requests
{
    public class GetCarPriceRequest
    {
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public int CC { get; set; }
        public int odometer { get; set; }

    }
}