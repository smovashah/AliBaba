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
    public class BusController : ControllerBase
    {
        private alibabaEntities _context;
        public BusController(alibabaEntities context)
        {
            _context = context;
        }

        //*GetByID GET: v3/bus/2
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Bus>> GetByID([FromRoute] int id)
        {
            // var bus = await _context.buss.FirstOrDefaultAsync(c => c.Id == id);
            var bus = await _context.Bus.FindAsync(id);
            // var bus = await context.buss.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (bus == null)
                return NotFound();
            return Ok(bus);
        }

        //*GetAll GET: v3/bus
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Bus>>> Get()
        {
            var buses = await _context.Bus.ToListAsync();

            if (buses == null)
                return NotFound();
            return Ok(buses);
        }

        //*Insert POST: v3/bus
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Bus>> Insert([FromBody] Bus model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Bus.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        //*UpdateById  PUT: v3/bus/5
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Bus>> Update(int id, [FromBody] Bus update)
        {

            if (id != update.bus_id)
                return BadRequest();

            var bus = await _context.Bus.FindAsync(id);
            bus.bus_id = update.bus_id;
            bus.bus_type = update.bus_type;
            bus.departure_terminal = update.departure_terminal;
            bus.destination_terminal = update.destination_terminal;
            bus.trip_id = update.trip_id;
            bus.Trip = update.Trip;

            _context.Update(bus);
            _context.SaveChanges();

            return Ok(bus);
        }


        //* DeleteByID  DELETE: v3/bus/3
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Bus>> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var bus = await _context.Bus.FindAsync(id);
            _context.Bus.Remove(bus);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}