using Microsoft.AspNetCore.Mvc;
using Server.ModlesBinders;
using Server.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Server.Models
{
    public class Car
    {
        public string? Manufacturer { get; set; }

        [DataType(DataType.Date)]
        [JsonConverter(typeof(JsonCustomDateConverter))]
        public DateTime MadeDate { get; set; }
    }

    [ModelBinder(BinderType = typeof(CarBinder))]
    public class CustomBinderCar : Car { }
}
