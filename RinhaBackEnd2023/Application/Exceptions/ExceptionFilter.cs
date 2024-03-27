using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RinhaBackEnd2023.Domain.Exceptions;
using RinhaBackEnd2023.Domain.Exceptions.Repository;
using System.Net;

namespace RinhaBackEnd2023.Application.Exceptions;

public class ExceptionFilter : IExceptionFilter
{
    private readonly Dictionary<Type, Action> _typesActions = [];
    private ExceptionContext? _context;

    public ExceptionFilter()
    {
        _typesActions.Add(typeof(InvalidRequest), () => ThrowInvalidRequestErrors(_context!));
        _typesActions.Add(typeof(RepositoryException), () => ThrowRepositoryExceptionErrors(_context!));
    }

    public void OnException(ExceptionContext context)
    {
        _context = context;

        if (_typesActions.TryGetValue(context.Exception.GetType(), out Action? action))
        {
            action();
        }
        else
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new
            {
                messageError = context.Exception.Message
            });
        }
    }

    private void ThrowInvalidRequestErrors(ExceptionContext context)
    {
        InvalidRequest? error = context.Exception as InvalidRequest;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableContent;
        context.Result = new ObjectResult(new
        {
            messageError = error!.MessageError
        });
    }

    private void ThrowRepositoryExceptionErrors(ExceptionContext context)
    {
        RepositoryException? error = context.Exception as RepositoryException;

        context.HttpContext.Response.StatusCode =  error!.RepositoryExceptionType is RepositoryExceptionType.EmptyReturn 
                                                   ? (int)HttpStatusCode.NotFound
                                                   : (int)HttpStatusCode.InternalServerError;

        context.Result = new ObjectResult(new
        {
            messageError = error!.MessageError
        });
    }
}
