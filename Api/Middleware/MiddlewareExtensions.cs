

namespace Autenticul.Gaming.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<AuthenticationMiddleware>();
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();

        }
    }
}
