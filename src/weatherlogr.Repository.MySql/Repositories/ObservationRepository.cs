using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.DTO;

namespace weatherlogr.Repository.MySql.Repositories
{
    public sealed class ObservationRepository : EFRepositoryBase<ObservationRow, Observation>, IObservationRepository
    {
        public ObservationRepository(WeatherContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}