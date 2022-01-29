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
    public class CityController : ControllerBase
    {
        private alibabaEntities _context;
        public CityController(alibabaEntities context)
        {
            _context = context;
        }

        //*GetByID GET: v3/city/2
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<City>> GetByID([FromRoute] int id)
        {
            // var city = await _context.citys.FirstOrDefaultAsync(c => c.Id == id);
            var city = await _context.City.FindAsync(id);
            // var city = await context.citys.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (city == null)
                return NotFound();
            return Ok(city);
        }

        //*GetAll GET: v3/city
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<City>>> Get()
        {
            var cityes = await _context.City.ToListAsync();

            if (cityes == null)
                return NotFound();
            return Ok(cityes);
        }

        //*Insert POST: v3/city
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<City>> Insert([FromBody] City model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.City.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        //*UpdateById  PUT: v3/city/5
        [HttpPut]
        [Route("{id}/{name}")]
        public async Task<ActionResult<City>> Update(int id, [FromBody] City update)
        {

            if (id != update.city_id)
                return BadRequest();

            var city = await _context.City.FindAsync(id);
            city.city_id = update.city_id;
            city.Trip = update.Trip;

            _context.Update(city);
            _context.SaveChanges();

            return Ok(city);
        }


        //* DeleteByID  DELETE: v3/city/3
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<City>> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var city = await _context.City.FindAsync(id);
            _context.City.Remove(city);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}