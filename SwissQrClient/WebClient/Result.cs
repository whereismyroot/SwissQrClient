using System;
using System.Net;
using Newtonsoft.Json;

namespace SwissQrClient.WebClient
{
    public class Result<T>
    {
        private Result()
        {
        }

        public T Data { get; private set; }

        public Error ErrorObj { get; private set; }

        public bool IsSuccess => ErrorObj == null;

        public static Result<T> Success(T data)
        {
            Result<T> result = new Result<T>
            {
                Data = data
            };

            return result;
        }

        public static Result<T> Error(Error error)
        {
            return new Result<T> { ErrorObj = error };
        }

        public static Result<T> Error(HttpStatusCode statusCode, string responseContent = null, Exception exception = null)
        {
            Error error;

            if (statusCode != HttpStatusCode.InternalServerError && !string.IsNullOrEmpty(responseContent))
            {
                error = JsonConvert.DeserializeObject<Error>(responseContent);
            }
            else
            {
                error = new Error(statusCode, responseContent, exception);
            }

            return new Result<T> { ErrorObj = error };
        }
    }
}
