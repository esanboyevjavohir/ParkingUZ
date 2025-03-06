﻿using Newtonsoft.Json;
using ParkingUZ.Application.Exceptions;
using ParkingUZ.Application.Models;
using ParkingUZ.Core.Common;
using ParkingUZ.Core.Exceptions;

namespace ParkingUZ.API.Middleware
{
    public class ExceptionHandlerMiddlewear
    {
        private readonly ILogger<ExceptionHandlerMiddlewear> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddlewear(ILogger<ExceptionHandlerMiddlewear> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.Message);

            var code = StatusCodes.Status500InternalServerError;
            var errors = new List<string> { ex.Message };

            if (ex.InnerException != null)
            {
                errors.Add(ex.InnerException.Message);
            }

            code = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                DirectoryNotFoundException => StatusCodes.Status404NotFound,
                ResourceNotFoundException => StatusCodes.Status404NotFound,
                BadHttpRequestException => StatusCodes.Status400BadRequest,
                UnprocessableRequestException => StatusCodes.Status422UnprocessableEntity,
                _ => code
            };

            var result = JsonConvert.SerializeObject(ApiResult<string>.Failure(
                new Errors(code.ToString(), code.ToString())));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}
