using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.Core.Services
{
    public class HostedServiceMessaging
    {
        public bool ShouldReloadStationCollectors { get; set; }

        public bool ShouldReloadSystemConfiguration { get; set; }
    }
}