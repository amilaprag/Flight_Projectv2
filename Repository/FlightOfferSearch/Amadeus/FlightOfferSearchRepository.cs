using Flight_Projectv2.Models.Amadeus;
using Flight_Projectv2.Services.SupplierConnector;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Projectv2.Repository.FlightSearch.Amadeus
{
    public class FlightSearchRepository : IFlightSearchRepository
    {
        private readonly ISupplierConnectorService SupplierConnectorSVCaller;
        private readonly ILogger Logger;

       public FlightSearchRepository(ISupplierConnectorService _SupplierConnectorSVCaller, ILogger<FlightSearchRepository> _Logger)
        {
            SupplierConnectorSVCaller = _SupplierConnectorSVCaller;
            Logger = _Logger;
        }
        public FlightSearchRS Search(FlightSearchRQ FlightSearchObj)
        {
            try
            {
                var SearchString = "flight-offers?originLocationCode=" + FlightSearchObj.OriginLocationCode.IataCode + "&destinationLocationCode=" + FlightSearchObj.DestinationLocationCode.IataCode + "&departureDate=" + FlightSearchObj.OriginLocationCode.DepartureDate.ToString("yyyy-MM-dd")+ "&returnDate="+ FlightSearchObj.DestinationLocationCode.ReturnDate.ToString("yyyy-MM-dd") + "&adults=" + FlightSearchObj.Pax.Adult + "&nonStop=" + FlightSearchObj.NonStop.ToString().ToLower() + "&max=250";
               
                FlightSearchRS FlightOffersSearchRS = JsonConvert.DeserializeObject<FlightSearchRS>((string)SupplierConnectorSVCaller.AmadeusGetCall(SearchString,"/v2/shopping/"));

                return FlightOffersSearchRS;
            }
            catch (Exception ErrorMessage)
            {
                Logger.LogError("return null with exeception", ErrorMessage);
                return null;
            }
        }
    }
}
