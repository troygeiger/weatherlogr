using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Services
{
    public class SystemConfigurationService : ISystemConfigurationService
    {
        SystemConfigurationEntry? entry;
        private readonly IServiceProvider serviceProvider;

        public SystemConfigurationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            
        }
        
        public SystemConfigurationEntry Configuration { get => TryGetConfig(); set => entry = value; }

        private SystemConfigurationEntry TryGetConfig()
        {
            if (entry is not null)
                return entry;

            using(IServiceScope scope = serviceProvider.CreateScope())
            {
                IConfigurationRepository? repository = scope.ServiceProvider.GetService<IConfigurationRepository>();
                if (repository == null)
                    return new();

                entry = repository.GetValue<SystemConfigurationEntry>();
                return entry;
            }
        }

        public void SaveChanges()
        {
            using(IServiceScope scope = serviceProvider.CreateScope())
            {
                IConfigurationRepository? repository = scope.ServiceProvider.GetService<IConfigurationRepository>();
                if (repository == null)
                    return;

                repository.SaveValue(Configuration);
            }
        }

        public void Reload()
        {
            entry = null;
            TryGetConfig();
        }
    }
}