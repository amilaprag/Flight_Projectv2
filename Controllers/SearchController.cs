using Flight_Projectv2.Models.Amadeus;
using Flight_Projectv2.Services.FlightSearch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Projectv2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private readonly IFlightSearchService IFlightOfferSVCaller;

        public SearchController(IFlightSearchService _IFlightOfferSVCaller)
        {
            IFlightOfferSVCaller = _IFlightOfferSVCaller;
        }

        [HttpPost]
        public JsonResult Search(FlightSearchRQ FlightSearchRQ)
        {
            return Json(IFlightOfferSVCaller.Search(FlightSearchRQ));
        }
    }
}
