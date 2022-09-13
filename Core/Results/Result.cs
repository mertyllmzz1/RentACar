using Core.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class Result : IResult
    {
        public StatusCode StatusCode { get; }

        public string UserMessage { get; }

        public Exception Exception { get; }
        public Result(StatusCode statusCode, string userMessage)
        {
            StatusCode = statusCode;
            UserMessage = userMessage;
        }
        public Result(StatusCode statusCode, string userMessage, Exception exception)
        {
            StatusCode = statusCode;
            UserMessage = userMessage;
            Exception = exception;
        }
        public static IResult FactoryResult(StatusCode statusCode, string userMessage)
        {
            return new Result(statusCode, userMessage);
        }
        public static IResult FactoryResult(StatusCode statusCode, string userMessage, Exception exception)
        {
            return new Result(statusCode, userMessage, exception);
        }
    }
}
