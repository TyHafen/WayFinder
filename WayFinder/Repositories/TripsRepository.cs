using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WayFinder.Interfaces;
using WayFinder.Models;

namespace WayFinder.Repositories
{
    public class TripsRepository : IRepository<Trip, int>
    {
        private readonly IDbConnection _db;
        public TripsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Trip Create(Trip tripData)
        {
            string sql = @"INSERT INTO trips (name)
            VALUES (@Name); 
             SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, tripData);
            tripData.Id = id;
            return tripData;
        }

        public string Delete(int id)
        {
            string sql = @"DELETE FROM trips WHERE id = @id LIMIT 1;";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "deleted";
            }
            throw new System.Exception("couldnt delete");
        }

        public void Edit(Trip original)
        {
            string sql = @"UPDATE trips SET name = @Name WHERE id = @Id;";
            _db.Execute(sql, original);

        }

        public List<Trip> GetAll()
        {
            string sql = @"SELECT * FROM trips;";
            return _db.Query<Trip>(sql).ToList();
        }

        public Trip GetById(int id)
        {
            string sql = @"SELECT * FROM trips WHERE trips.id = @id;";
            return _db.Query<Trip>(sql, new { id }).FirstOrDefault();
        }


    }
}

