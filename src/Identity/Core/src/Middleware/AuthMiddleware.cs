using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        if (!string.IsNullOrEmpty(token) && TokenManager.DecryptToken(token) != null)
        {
            await _next(context);
        }
        else
        {
            context.Response.StatusCode = 401;
        }
    }
}
