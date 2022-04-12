using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WayFinder.Models;
using WayFinder.Services;

namespace WayFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {

        private readonly ReservationsService _rs;
        public ReservationsController(ReservationsService rs)
        {
            _rs = rs;
        }
        [HttpGet]
        public ActionResult<List<ReservationsController>> GetAllByTripId(int id)
        {
            try
            {
                List<Reservation> reservations = _rs.GetAllByTripId(id);
                return Ok(reservations);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Reservation> Create([FromBody] Reservation reservationData)
        {
            try
            {
                Reservation reservation = _rs.Create(reservationData);
                return Ok(reservation);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _rs.Delete(id);
                return Ok("deleted the reservation");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }


        }
        [HttpPut("{id}")]
        public ActionResult<Reservation> Edit([FromBody] Reservation reservationData, int id)
        {
            try
            {
                reservationData.Id = id;
                Reservation reservation = _rs.Edit(reservationData);
                return Ok(reservation);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("{id}")]
        public ActionResult<Trip> GetById(int id)
        {
            try
            {
                Reservation reservation = _rs.GetById(id);
                return Ok(reservation);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);


            }



        }
    }
}