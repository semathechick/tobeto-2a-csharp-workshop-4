using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class RoleAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
           
            var userRoles = context.User.Claims
                .Where(c => c.Type == "role")
                .Select(c => c.Value)
                .ToList();

            
            if (userRoles.Contains("admin"))
            {
                
                await _next(context);
            }
            else
            {
                
                context.Response.StatusCode = 403; 
                await context.Response.WriteAsync("Yetkiniz bulunmamaktadır.");
            }
        }
    }
}
