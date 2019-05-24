namespace CarManagement.Core.Responses
{
    public class GetCarPriceResponse : GenericResponse
    {
        public int price { get; set; }
        public int count { get; set; }
    }
}