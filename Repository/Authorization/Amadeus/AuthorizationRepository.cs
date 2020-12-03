using Flight_Projectv2.Models.Amadeus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flight_Projectv2.Repository.Authorization.Amadeus
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<AuthorizationRepository> Logger;

        public AuthorizationRepository(IConfiguration _Configuration,ILogger<AuthorizationRepository> _Logger)
        {
            Configuration = _Configuration;
            Logger = _Logger;
        }

        #region AmadeusAuth
        public string AmadeusAuth()
        {
            try
            {
                Dictionary<string, string> Params = new Dictionary<string, string>();
                Params.Add("client_id", Configuration["AmadeusConfiguration:" + Configuration["AmadeusConfiguration:Environment"] + ":ClientId"]);
                Params.Add("client_secret", Configuration["AmadeusConfiguration:Test:ClientSecret"]);
                Params.Add("grant_type", Configuration["AmadeusConfiguration:Test:GrantType"]);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Configuration["AmadeusConfiguration:Test:BaseUri"]);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

                    var postTask = client.PostAsync("v1/security/oauth2/token", new FormUrlEncodedContent(Params));
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        AuthorizationRSModel AuthorizationRSModelObj = JsonConvert.DeserializeObject<AuthorizationRSModel>(result.Content.ReadAsStringAsync().Result);
                        return AuthorizationRSModelObj.Access_Token;
                    }

                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion
    }
}
