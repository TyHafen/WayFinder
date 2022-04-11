using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WayFinder.Models;
using WayFinder.Services;

namespace WayFinder.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TripsController : ControllerBase
    {
        private readonly TripsService _ts;
        public TripsController(TripsService ts)
        {
            _ts = ts;
        }

        [HttpGet]
        public ActionResult<List<TripsController>> GetAll()
        {
            try
            {
                List<Trip> trips = _ts.GetAll();
                return Ok(trips);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Trip> Create([FromBody] Trip tripData)
        {
            try
            {
                Trip trip = _ts.Create(tripData);
                return Ok(trip);
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
                Trip trip = _ts.GetById(id);
                return Ok(trip);
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
                _ts.Delete(id);
                return Ok("deleted the Trip :(");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Trip> Edit([FromBody] Trip tripData, int id)
        {
            try
            {
                tripData.Id = id;
                Trip trip = _ts.Edit(tripData);
                return Ok(trip);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }





    }
}