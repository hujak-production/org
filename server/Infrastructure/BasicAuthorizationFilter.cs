using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using server.Model.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace server.Infrastructure
{
    public class BasicAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string _realm;

        public BasicAuthorizationFilter(string realm)
        {
            if (string.IsNullOrEmpty(realm))
            {
                throw new ArgumentException($"Passed realm: {realm} is not valid. The value cannot be null or empty.");
            }

            _realm = realm;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //If the action method does not require authorization request.
            if (context.ActionDescriptor.EndpointMetadata.Any(atr =>
                atr.GetType() == typeof(AllowAnonymousAttribute)))
            {
                return;
            }

            try
            {
                string authHeader = context.HttpContext.Request.Headers["Authorization"];
                if (authHeader != null)
                {
                    var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
                    if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(),
                        StringComparison.OrdinalIgnoreCase))
                    {
                        var credentials = Encoding.UTF8
                            .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                            .Split(':', 2);
                        if (credentials.Length == 2)
                        {
                            if (IsAuthorized(context, credentials[0], credentials[1]))
                            {
                                return;
                            }
                        }
                    }
                }
                ReturnUnauthorizedResult(context);
            }
            catch (FormatException)
            {
                ReturnUnauthorizedResult(context);
            }
        }

        private bool IsAuthorized(AuthorizationFilterContext context, string username, string password)
        {
            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            return userService.IsValidUser(username, password);
        }

        private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
        {
            // Return 401 and a basic authentication challenge (causes browser to show login dialog)
            context.HttpContext.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{_realm}\"";
            context.Result = new UnauthorizedResult();
        }
    }
}
