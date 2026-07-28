using Ecommerce.Exception.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommerce.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is DomainException)
        {
            HandleDomainException(context);
            return;
        }

        HandleUnkownexception(context);

    }

    private static void HandleDomainException(ExceptionContext context)
    {
        context.Result = new BadRequestObjectResult(new
            {
                title = "Erro de regra de negócio",
                status = StatusCodes.Status400BadRequest,
                message = context.Exception.Message
            }
        );
    }

    private static void HandleUnkownexception(ExceptionContext context)
    {
        context.Result = new ObjectResult(new
            {
                title = "Erro interno do servidor",
                status = StatusCodes.Status500InternalServerError,
                message = "Ocorreu um erro inesperado"
            }
        )
        {
          StatusCode = StatusCodes.Status500InternalServerError  
        };
    }
}