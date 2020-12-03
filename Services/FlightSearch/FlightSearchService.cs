using Flight_Projectv2.Models.Amadeus;
using Flight_Projectv2.Repository.FlightSearch;
using Flight_Projectv2.Repository.FlightSearch.Amadeus;
using Flight_Projectv2.Services.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flight_Projectv2.Services.FlightSearch
{
    public class FlightSearchService : IFlightSearchService
    {
        private readonly ILogger<IFlightSearchService> Logger;
        private readonly IFlightSearchRepository FlightSearchRPCaller;

        public FlightSearchService(ILogger<IFlightSearchService> _Logger,IFlightSearchRepository _FlightSearchRPCaller)
        {
            Logger = _Logger;
            FlightSearchRPCaller = _FlightSearchRPCaller;
        }

        #region Search
        public FlightSearchRS Search(FlightSearchRQ FlightSearchObj)
        {
            try
            {
                switch (FlightSearchObj.Service)
                {
                    case "FlightOfferSearchGet":
                          FlightSearchRS FlightSearchRespose = FlightSearchRPCaller.Search(FlightSearchObj);
                          return FlightSearchRespose;
                    


                    default:
                    break;
                }
                Logger.LogError("return null ");
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
