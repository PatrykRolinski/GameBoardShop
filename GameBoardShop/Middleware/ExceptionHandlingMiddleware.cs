using GameBoardShop.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GameBoardShop.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
       
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException)
            {
                context.Response.Redirect("/api/Error/404");
            }
            catch (Exception)
            {
                context.Response.Redirect("/api/Error");
            }
        }
    }
}
