using Flight_Projectv2.Models.Amadeus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Projectv2.Services.FlightSearch
{
    public interface IFlightSearchService
    {
        FlightSearchRS Search(FlightSearchRQ FlightSearchObj);
    } 
}
