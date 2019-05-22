namespace CarManagement.Core.Requests
{
    public class GetCarPriceRequest
    {
        public string make { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string CC { get; set; }
        public string odometer { get; set; }

    }
}