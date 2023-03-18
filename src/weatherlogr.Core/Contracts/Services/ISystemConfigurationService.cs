using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Services
{
    public interface ISystemConfigurationService
    {
        SystemConfigurationEntry Configuration { get; set; }

        void SaveChanges();

        void Reload();
    }
}