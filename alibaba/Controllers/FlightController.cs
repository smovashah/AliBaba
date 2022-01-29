using Model;
using System.Collections.Generic;
using System.Linq;
using Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Controller
{
    [ApiController]
    [Route("v3/[controller]")]
    public class FlightController : ControllerBase
    {
        private alibabaEntities _context;
        public FlightController(alibabaEntities context)
        {
            _context = context;
        }

        //*GetByID GET: v3/flight/2
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Flight>> GetByID([FromRoute] int id)
        {
            // var flight = await _context.flights.FirstOrDefaultAsync(c => c.Id == id);
            var flight = await _context.Flight.FindAsync(id);
            // var flight = await context.flights.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (flight == null)
                return NotFound();
            return Ok(flight);
        }

        //*GetAll GET: v3/flight
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Flight>>> Get()
        {
            var flightes = await _context.Flight.ToListAsync();

            if (flightes == null)
                return NotFound();
            return Ok(flightes);
        }

        //*Insert POST: v3/flight
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Flight>> Insert([FromBody] Flight model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Flight.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        //*UpdateById  PUT: v3/flight/5
        [HttpPut]
        [Route("{id}/{name}")]
        public async Task<ActionResult<Flight>> Update(int id, [FromBody] Flight update)
        {

            if (id != update.flight_id)
                return BadRequest();

            var flight = await _context.Flight.FindAsync(id);
            flight.flight_id = update.flight_id;

            _context.Update(flight);
            _context.SaveChanges();

            return Ok(flight);
        }


        //* DeleteByID  DELETE: v3/flight/3
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Flight>> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var flight = await _context.Flight.FindAsync(id);
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}