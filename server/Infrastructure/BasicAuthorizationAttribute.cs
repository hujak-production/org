using Microsoft.AspNetCore.Mvc;
using System;

namespace Server.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BasicAuthorizationAttribute : TypeFilterAttribute
    {
        public BasicAuthorizationAttribute(string realm = @"My Realm") : base(typeof(BasicAuthorizationFilter))
        {
            Arguments = new object[] { realm };
        }
    }
}
