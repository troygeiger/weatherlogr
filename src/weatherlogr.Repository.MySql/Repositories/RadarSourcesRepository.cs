using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.DTO;
using weatherlogr.Repository.MySql.Models;

namespace weatherlogr.Repository.MySql.Repositories
{
    public sealed class RadarSourcesRepository
      : EFRepositoryBase<RadarSourceRow, RadarSource>, IRadarSourcesRepository
    {
        public RadarSourcesRepository(WeatherContext context, IMapper mapper) : base(context, mapper)
        {
        }

      
    }
}