using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingUZ.Application.Models;
using ParkingUZ.Core.Common;

namespace ParkingUZ.API.Filters
{
    public class ValidateModelAttribute : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, 
            ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(modelState => modelState.Errors)
                    .Select(modelError => Errors.InternalServerError);

                context.Result = new BadRequestObjectResult(
                    ApiResult<string>.Failure(errors.First()));
            }

            await next();
        }
    }
}
