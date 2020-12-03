﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Projectv2.Models.Amadeus
{
    public class OriginLocationCode
    {
        public string IataCode { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class DestinationLocationCode
    {
        public string IataCode { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class Pax
    {
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Infants { get; set; }
    }
    public class FlightSearchRQ
    {
        public string Service { get; set;  }
        public OriginLocationCode OriginLocationCode { get; set; }
        public DestinationLocationCode DestinationLocationCode { get; set; }
        public Pax Pax { get; set; }
        public string TravelClass { get; set; }
        public List<string> ExcludedAirlineCodes { get; set; }
        public bool NonStop { get; set; }
        public string CurrencyCode { get; set; }
        public long MaxPrice { get; set; }
        public int Max { get; set; }
    }
}
