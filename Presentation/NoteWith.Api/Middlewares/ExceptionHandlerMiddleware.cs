using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mime;
using NoteWith.Domain.DTOModels.CustomExceptionModels;

namespace NoteWith.Api.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
        private readonly RequestDelegate next;

        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //request loging
                await next.Invoke(context);
                //response loging
            }
            catch (Exception eror)
            {
                logger.LogInformation(eror.Message);//loglama yapılacka
                context.Response.ContentType = MediaTypeNames.Application.Json;
                if (eror is UnAuthEx)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsJsonAsync(eror.Message);
                }                    
                else if(eror is CusEx)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsJsonAsync(eror.Message);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsJsonAsync("Bir Hata Oluştu");
                }
                    
            }

        }
    }
}

