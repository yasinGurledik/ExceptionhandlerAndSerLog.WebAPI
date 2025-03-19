using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace ExceptionhandlerAndSerLog.WebAPI
{
	public class ExceptionHandler : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
		{

			httpContext.Response.StatusCode = 400;
			await httpContext.Response.WriteAsJsonAsync(new {message = exception.Message} );
			if(exception.GetType() == typeof(ValidationException))
			{
				httpContext.Response.StatusCode = 403;
			}
			return true;

		}
	}
}
