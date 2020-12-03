using Flight_Projectv2.Repository.Authorization;
using Flight_Projectv2.Repository.Authorization.Amadeus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flight_Projectv2.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRepository AuthorizationRepositoryCaller;
        private readonly ILogger Logger;

        public AuthorizationService(IAuthorizationRepository _AuthorizationRepositoryCaller,ILogger<AuthorizationRepository> _Logger)
        {
            AuthorizationRepositoryCaller = _AuthorizationRepositoryCaller;
            Logger = _Logger;
         
        }
        public String AmadeusAuthorizationService()
        {
            return AuthorizationRepositoryCaller.AmadeusAuth();
        }
    }
}
