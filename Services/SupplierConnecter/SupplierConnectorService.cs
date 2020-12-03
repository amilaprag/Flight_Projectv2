using Flight_Projectv2.Models.Amadeus;
using Flight_Projectv2.Repository.SupplierConnecter;
using Flight_Projectv2.Repository.SupplierConnecter.Amadeus;
using Flight_Projectv2.Services.SupplierConnector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Projectv2.Services.SupplierConnecter
{
    public class SupplierConnectorService : ISupplierConnectorService
    {
        private readonly ILogger<SupplierConnectorService> Logger;
        private readonly ISupplierConnectorRepository SupplierConnectorRPCaller;

        public SupplierConnectorService(ILogger<SupplierConnectorService>_Logger,ISupplierConnectorRepository _SupplierConnectorRPCaller)
        {
            Logger = _Logger;
            SupplierConnectorRPCaller = _SupplierConnectorRPCaller;
        }
        public object AmadeusGetCall(string SearchString,String Url)
        {
            return SupplierConnectorRPCaller.AmadeusGetCall(SearchString, Url);
        }
    }
}
