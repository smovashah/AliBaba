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
    public class CountryController : ControllerBase
    {
        private alibabaEntities _context;
        public CountryController(alibabaEntities context)
        {
            _context = context;
        }

        //*GetByID GET: v3/country/2
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Country>> GetByID([FromRoute] int id)
        {
            // var country = await _context.countrys.FirstOrDefaultAsync(c => c.Id == id);
            var country = await _context.Country.FindAsync(id);
            // var country = await context.countrys.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
                return NotFound();
            return Ok(country);
        }

        //*GetAll GET: v3/country
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Country>>> Get()
        {
            var countryes = await _context.Country.ToListAsync();

            if (countryes == null)
                return NotFound();
            return Ok(countryes);
        }

        //*Insert POST: v3/country
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Country>> Insert([FromBody] Country model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Country.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        //*UpdateById  PUT: v3/country/5
        [HttpPut]
        [Route("{id}/{name}")]
        public async Task<ActionResult<Country>> Update(int id, [FromBody] Country update)
        {

            if (id != update.country_id)
                return BadRequest();

            var country = await _context.Country.FindAsync(id);
            country.country_id = update.country_id;

            _context.Update(country);
            _context.SaveChanges();

            return Ok(country);
        }


        //* DeleteByID  DELETE: v3/country/3
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Country>> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var country = await _context.Country.FindAsync(id);
            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}