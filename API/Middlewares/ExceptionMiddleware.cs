<<<<<<< HEAD
=======
namespace API.Middlewares;

>>>>>>> datingapp/main
using System.Net;
using System.Text.Json;
using API.Errors;

<<<<<<< HEAD
namespace API.Middlewares;

=======
>>>>>>> datingapp/main
public class ExceptionMiddleware(
    RequestDelegate next,
    ILogger<ExceptionMiddleware> logger,
    IHostEnvironment env)
{
<<<<<<< HEAD
        public async Task InvokeAsync(HttpContext context){
=======
    public async Task InvokeAsync(HttpContext context)
    {
>>>>>>> datingapp/main
        try
        {
            await next(context);
        }
<<<<<<< HEAD
        catch(Exception ex)
=======
        catch (Exception ex)
>>>>>>> datingapp/main
        {
            logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

<<<<<<< HEAD
            var response = env.IsDevelopment() 
=======
            var response = env.IsDevelopment()
>>>>>>> datingapp/main
                ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace)
                : new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> datingapp/main
