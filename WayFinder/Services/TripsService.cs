using System.Collections.Generic;
using WayFinder.Models;
using WayFinder.Repositories;

namespace WayFinder.Services
{
    public class TripsService
    {
        private readonly TripsRepository _tRepo;
        public TripsService(TripsRepository tRepo)
        {
            _tRepo = tRepo;
        }

        internal List<Trip> GetAll()
        {
            return _tRepo.GetAll();
        }

        internal Trip Create(Trip tripData)
        {
            return _tRepo.Create(tripData);
        }

        internal Trip GetById(int id)
        {
            return _tRepo.GetById(id);
        }

        internal string Delete(int id)
        {
            return _tRepo.Delete(id);

        }

        internal Trip Edit(Trip update)
        {
            Trip original = _tRepo.GetById(update.Id);
            original.Name = update.Name ?? original.Name;
            _tRepo.Edit(original);
            return original;
        }
    }
}