using Microsoft.AspNetCore.Http;
using SongWriter.Logic;
using SongWriter.Logic.Models;
using SongWriter.Logic.Processing.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SongWriter.Web.Infrastructure
{
    public class WebUserIdentifier : IUserIdentifier
    {
        private readonly IHttpContextAccessor httpContextAccesor;
        public WebUserIdentifier(IHttpContextAccessor httpContextAccesor)
        {
            this.httpContextAccesor = httpContextAccesor;
        }

        public User Identify()
        {
            // Go through and try to get user name and user id from claims
            // Clean up this method at some point


            var http = this.httpContextAccesor.HttpContext;

            // Get user name
            var userName = http?.User?.Identity?.Name;

            if (string.IsNullOrWhiteSpace(userName))
            {
                return null;
            }

            var serialNumberClaim = http?.User?.Claims.Where(c => c.Type == ClaimTypes.SerialNumber).FirstOrDefault();

            if(serialNumberClaim == null)
            {
                throw new InvalidOperationException("Cannot find User Id claim");
            }


            if (Int32.TryParse(serialNumberClaim.Value, out int userId))
            {
                return new User()
                {
                    Id = userId,
                    Name = userName
                };
            }

            throw new InvalidOperationException("Cannot parse User Id claim");

        }
    }
}
