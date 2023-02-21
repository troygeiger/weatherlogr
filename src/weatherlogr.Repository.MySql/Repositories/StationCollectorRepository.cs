using AutoMapper;
using Microsoft.EntityFrameworkCore;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.DTO;
using weatherlogr.Repository.MySql.Models;

namespace weatherlogr.Repository.MySql.Repositories;

public sealed class StationCollectorRepository
    : EFRepositoryBase<StationCollectorRow, StationCollector>, IStationCollectorRepository
{
    public StationCollectorRepository(WeatherContext context, IMapper mapper) : base(context, mapper)
    {
    }
}