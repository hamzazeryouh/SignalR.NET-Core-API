namespace API.Application.Exceptions
{
    using API.Domain.Exceptions;
    using System;

    public class UnAcceptableRequestException : BCIException
    {
        public string MessageCode { get; set; }

        public UnAcceptableRequestException()
        { }

        public UnAcceptableRequestException(string message) : base(message)
        { }

        public UnAcceptableRequestException(string message, string messageCode) : base(message)
        {
            MessageCode = messageCode;
        }

        public UnAcceptableRequestException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
