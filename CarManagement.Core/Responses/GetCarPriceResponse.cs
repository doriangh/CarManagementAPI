namespace CarManagement.Core.Responses
{
    public class GetCarPriceResponse : GenericResponse
    {
        public int Price { get; set; }
        public int Count { get; set; }
    }
}