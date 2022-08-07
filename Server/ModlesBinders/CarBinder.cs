using Microsoft.AspNetCore.Mvc.ModelBinding;
using Server.Models;
using Server.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server.ModlesBinders
{
    public class CarBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Console.WriteLine("*****************");
            Console.WriteLine("Step 4 - 3: custom model binding");
            Console.WriteLine("*****************");

            var result = await JsonSerializer.DeserializeAsync<CustomBinderCar>(bindingContext.HttpContext.Request.Body, Constants.DefaultJsonSerializerOptions);

            bindingContext.Result = ModelBindingResult.Success(result);
        }
    }
}
