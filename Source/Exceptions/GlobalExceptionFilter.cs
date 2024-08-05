using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        List<string> errors = new List<string>();
        var statusCode = context.Exception switch
        {

            ValidationException => StatusCodes.Status400BadRequest,

            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

            InternalServerErrorException => StatusCodes.Status500InternalServerError,

            _ => StatusCodes.Status500InternalServerError
        };

        errors.Add(context.Exception.Message);
        
        context.Result = new ObjectResult(new
        {
            errors
        })
        {
            StatusCode = statusCode
        };
    }
}