using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UserManagementSystem.Models;

namespace UserManagementSystem.Utils
{
    /// <summary>
    /// A request validator model 
    /// to handle bad request responses.
    /// </summary>
    public static class RequestValidator
    {
        public static IActionResult ValidateRequest(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var errors = modelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return new BadRequestObjectResult(new ApiResponse<object>
                (
                    modelState,
                    "Validation failed",
                    400,
                    false
                ));
            }

            return null;
        }
    }
}
