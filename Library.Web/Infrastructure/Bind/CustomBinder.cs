using System.Threading.Tasks;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Library.Web.Infrastructure.Bind
{
    public class CustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var someValues = bindingContext.ValueProvider.GetValue("Email");

            var user = new User
            {
                Email = someValues.FirstValue
            };
            
            bindingContext.Result = ModelBindingResult.Success(user);
            
            return Task.CompletedTask;
        }
    }
}