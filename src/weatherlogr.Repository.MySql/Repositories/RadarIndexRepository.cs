using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.DTO;

namespace weatherlogr.Repository.MySql.Repositories
{
    public sealed class RadarIndexRepository
        : EFRepositoryBase<RadarIndexRow, RadarIndex>, IRadarIndexRepository
    {
        public RadarIndexRepository(WeatherContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}