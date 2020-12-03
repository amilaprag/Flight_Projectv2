using Flight_Projectv2.Models.Amadeus;
using Flight_Projectv2.Services.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flight_Projectv2.Repository.SupplierConnecter.Amadeus
{
    public class SupplierConnectorRepository : ISupplierConnectorRepository
    {
        private readonly IAuthorizationService IAutherizationSVCaller;
        private readonly ILogger<SupplierConnectorRepository> Logger;
        private readonly IConfiguration Configuration;

        public SupplierConnectorRepository(IAuthorizationService _IAutherizationSVCaller,ILogger<SupplierConnectorRepository> _Logger,IConfiguration _Configuration)
        {
            IAutherizationSVCaller = _IAutherizationSVCaller;
            Logger = _Logger;
            Configuration = _Configuration;
        }


        #region AmadeusGet
        public object AmadeusGetCall(string SearchString, string Url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var token = IAutherizationSVCaller.AmadeusAuthorizationService();

                    String UrlParam = Configuration["AmadeusConfiguration:" + Configuration["AmadeusConfiguration:Environment"] + ":BaseUri"] + Url;
                    client.BaseAddress = new Uri(UrlParam);
                    string tokenfinal = "Bearer " + token;
                    client.DefaultRequestHeaders.Add("Authorization", tokenfinal);

                    var responseTask = client.GetAsync(SearchString);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var response = result.Content.ReadAsStringAsync().Result;
                        return response;
                    }
                    else
                    {
                        var ErorResponse = result.Content.ReadAsStringAsync().Result;
                        Logger.LogError("return null with exeception", ErorResponse);
                    }
                }
                return null;
            }
            catch (Exception ErrorMessage)
            {
                Logger.LogError("return null with exeception", ErrorMessage);
                return null;
            }
        }
        #endregion
    }
}
