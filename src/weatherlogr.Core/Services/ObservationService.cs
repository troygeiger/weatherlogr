using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;
using weatherlogr.Core.Extensions;

namespace weatherlogr.Core.Services
{
    public class ObservationService : IObservationService
    {
        private readonly IObservationRepository observationsRepo;

        public ObservationService(IObservationRepository observations)
        {
            this.observationsRepo = observations;
        }

        public bool AutoSaveChanges { get => observationsRepo.AutoSaveChanges; set => observationsRepo.AutoSaveChanges = value; }

        public async Task<ObservationRow> AddObservation(ObservationRow observation, CancellationToken cancellationToken = default)
        {
            return await observationsRepo.AddNewItemAsync(observation, cancellationToken);
        }

        public async Task<bool> AddObservationRangeAsync(IEnumerable<ObservationRow> observations, CancellationToken cancellationToken = default)
        {
            bool origAutoSave = AutoSaveChanges;
            AutoSaveChanges = false;
            try
            {
                foreach (var item in observations)
                {
                    observationsRepo.AddNewItem(item);
                }
                await observationsRepo.SaveChangesAsync(cancellationToken);
            }
            catch (System.Exception)
            {

                return false;
            }
            finally
            {
                AutoSaveChanges = origAutoSave;
            }
            return true;
        }

        public async Task<IEnumerable<ObservationRow>> GetAllStationObservations(string stationIdentifier, CancellationToken cancellationToken = default)
        {
            return await observationsRepo
                .AsQueryable()
                .Where(o => o.StationID == stationIdentifier)
                .ToArrayAsync(cancellationToken);
        }

        public Task<IEnumerable<ObservationRow>> GetStationObservations(string stationIdentifier, DateTime start, DateTime end)
        {
            return GetStationObservations(stationIdentifier, start, end, default);
        }

        public async Task<IEnumerable<ObservationRow>> GetStationObservations(string stationIdentifier, DateTime start, DateTime end, CancellationToken cancellationToken = default)
        {
            return await observationsRepo
                .AsQueryable()
                .Where(o => o.StationID == stationIdentifier && o.EntryDate >= start && o.EntryDate <= end)
                .ToArrayAsync(cancellationToken);
        }

        public IQueryable<ObservationRow> QueryObservations()
        {
            return observationsRepo.AsQueryable();
        }

        public async Task SaveChangesAsync()
        {
            await observationsRepo.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await observationsRepo.SaveChangesAsync(cancellationToken);
        }
    }
}