using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Library.Web.Infrastructure.Bind.Providers
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(string) ? new CustomModelBinder() : null;
        }
    }
}