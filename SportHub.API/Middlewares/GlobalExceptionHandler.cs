using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportHub.API.Exceptions;

namespace SportHub.API.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var(statusCode, title) = exception switch
            {
                NotFoundException => (StatusCodes.Status404NotFound, "Không tìm thấy dữ liệu"),
                ConflictException => (StatusCodes.Status409Conflict, "Xung đột dữ liệu"),
                UnauthorizedException => (StatusCodes.Status401Unauthorized, "Xác thực thất bại"),
                _ => (StatusCodes.Status500InternalServerError, "Lỗi hệ thống")
            };

            if (statusCode == StatusCodes.Status500InternalServerError)
                _logger.LogError(exception, "Unhandled exception");

            var problem = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = statusCode == StatusCodes.Status500InternalServerError
                                        ? "Đã có lỗi xảy ra, vui lòng thử lại sau." : exception.Message,
                Instance = httpContext.Request.Path
            };
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
            return true;
        }
    }
}
