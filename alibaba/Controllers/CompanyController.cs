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
    public class CompanyController : ControllerBase
    {
        private alibabaEntities _context;
        public CompanyController(alibabaEntities context)
        {
            _context = context;
        }

        //*GetByID GET: v3/company/2
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Company>> GetByID([FromRoute] int id)
        {
            // var company = await _context.companys.FirstOrDefaultAsync(c => c.Id == id);
            var company = await _context.Company.FindAsync(id);
            // var company = await context.companys.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (company == null)
                return NotFound();
            return Ok(company);
        }

        //*GetAll GET: v3/company
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Company>>> Get()
        {
            var companyes = await _context.Company.ToListAsync();

            if (companyes == null)
                return NotFound();
            return Ok(companyes);
        }

        //*Insert POST: v3/company
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Company>> Insert([FromBody] Company model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Company.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        //*UpdateById  PUT: v3/company/5
        [HttpPut]
        [Route("{id}/{name}")]
        public async Task<ActionResult<Company>> Update(int id, [FromBody] Company update)
        {

            if (id != update.company_id)
                return BadRequest();

            var company = await _context.Company.FindAsync(id);
            company.company_id = update.company_id;
            company.Trip = update.Trip;

            _context.Update(company);
            _context.SaveChanges();

            return Ok(company);
        }


        //* DeleteByID  DELETE: v3/company/3
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Company>> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}