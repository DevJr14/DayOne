using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Serilog;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RESTApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = await Result<string>.FailAsync(error.Message);

                response.StatusCode = error switch
                {
                    AppException e => (int)HttpStatusCode.BadRequest,// custom application error
                    KeyNotFoundException e => (int)HttpStatusCode.NotFound,// not found error
                    _ => (int)HttpStatusCode.InternalServerError,// unhandled error
                };

                var result = JsonSerializer.Serialize(responseModel);
                //Log to both console, .txt file and .json file.
                await Task.Run(() => Log.Error($"Something went wrong: {error}"));

                await response.WriteAsync(result);
            }
        }
    }
}
