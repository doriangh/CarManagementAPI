using Microsoft.ML.Data;

namespace CarManagement.Core.Entities
{
    public class ModelInput
    {
        [ColumnName("cc")] [LoadColumn(0)] public float Cc { get; set; }


        [ColumnName("fuel")] [LoadColumn(1)] public string Fuel { get; set; }


        [ColumnName("make")] [LoadColumn(2)] public string Make { get; set; }


        [ColumnName("model")] [LoadColumn(3)] public string Model { get; set; }


        [ColumnName("odometer")]
        [LoadColumn(4)]
        public float Odometer { get; set; }


        [ColumnName("power")] [LoadColumn(5)] public float Power { get; set; }


        [ColumnName("price")] [LoadColumn(6)] public float Price { get; set; }


        [ColumnName("year")] [LoadColumn(7)] public float Year { get; set; }
    }
}