using Flight_Projectv2.Models.Amadeus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Projectv2.Repository.FlightSearch.Amadeus
{
    public interface IFlightSearchRepository
    {
        FlightSearchRS Search(FlightSearchRQ FlightSearchObj);
    }
}
