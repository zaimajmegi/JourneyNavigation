using System;
using System.Net;

namespace TaskManagement.API.Middlewares;

public class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public BaseException(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }

    public BaseException(HttpStatusCode statusCode, string message)
    : base(message)
    {
        StatusCode = statusCode;
    }
}
