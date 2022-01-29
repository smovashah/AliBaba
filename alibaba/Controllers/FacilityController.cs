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
    public class FacilityController : ControllerBase
    {
        private alibabaEntities _context;
        public FacilityController(alibabaEntities context)
        {
            _context = context;
        }

        //*GetByID GET: v3/facility/2
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Facility>> GetByID([FromRoute] int id)
        {
            // var facility = await _context.facilitys.FirstOrDefaultAsync(c => c.Id == id);
            var facility = await _context.Facility.FindAsync(id);
            // var facility = await context.facilitys.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (facility == null)
                return NotFound();
            return Ok(facility);
        }

        //*GetAll GET: v3/facility
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Facility>>> Get()
        {
            var facilityes = await _context.Facility.ToListAsync();

            if (facilityes == null)
                return NotFound();
            return Ok(facilityes);
        }

        //*Insert POST: v3/facility
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Facility>> Insert([FromBody] Facility model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Facility.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        //*UpdateById  PUT: v3/facility/5
        [HttpPut]
        [Route("{id}/{name}")]
        public async Task<ActionResult<Facility>> Update(int id, [FromBody] Facility update)
        {

            if (id != update.facility_id)
                return BadRequest();

            var facility = await _context.Facility.FindAsync(id);
            facility.facility_id = update.facility_id;

            _context.Update(facility);
            _context.SaveChanges();

            return Ok(facility);
        }


        //* DeleteByID  DELETE: v3/facility/3
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Facility>> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var facility = await _context.Facility.FindAsync(id);
            _context.Facility.Remove(facility);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}