using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WayFinder.Interfaces;
using WayFinder.Models;

namespace WayFinder.Repositories
{
    public class ReservationsRepository : IRepository<Reservation, int>
    {
        private readonly IDbConnection _db;
        public ReservationsRepository(IDbConnection db)
        {
            _db = db;
        }
        public Reservation Create(Reservation reservationData)
        {
            string sql = @"INSERT INTO reservations (type, name, confirmationNumber, address, date, cost, tripId) 
  VALUES(@Type, @Name, @ConfirmationNumber, @Address, @Date, @cost, @tripId); SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>
          (sql, reservationData);
            reservationData.Id = id;
            return reservationData;

        }

        public string Delete(int id)
        {
            string sql = @"DELETE FROM reservations WHERE id = @id LIMIT 1";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "Deleted";
            }
            throw new System.Exception("couldnt delete reservation");
        }

        public void Edit(Reservation data)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAll()
        {
            string sql = "Select * FROM reservations";
            return _db.Query<Reservation>(sql).ToList();
        }

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}