using Microsoft.AspNetCore.Mvc.ModelBinding;
using Server.Models;

namespace Server.ModlesBinders
{
    public class CarModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(CustomBinderCar))
                return new CarBinder();
            else
                return null;
        }
    }
}
