using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace KFisher.WebApi.Extensions
{
    public static class ApiControllerExtensions
    {
        public static Guid GetUserId(this ApiController controller)
        {
            return new Guid(controller?.User?.Identity?.GetUserId());
        }
    }
}