using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unikc.DAL.Contexts;
using Unikc.DAL.Dto;
using Unikc.DAL.Entities;

namespace UNIKK_API.Controllers
{

    [Route("api/controller")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("/GetPeopleList")]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            try
            {
                return await _context.People.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("/GetPersonById/{IdPerson}", Name = "GetPersonById")]
        public async Task<ActionResult<Person>> GetPersonById(Int16 Id)
        {
            try
            {
                var person = await _context.People.Where(x => x.Id == Id).FirstOrDefaultAsync();
                return person;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost("/CreatePerson")]
        public async Task<ActionResult> Post([FromBody] Person entity)
        {
            try
            {
                await _context.People.AddAsync(entity);
                await _context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetPersonById", new { id = entity.Id, entity });


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("/UpdatePerson")]
        public async Task<ActionResult> Put(Int16 Id, [FromBody]Person value)
        {
            try
            {
                if (Id != value.Id)
                {
                    return BadRequest();
                }
                _context.Entry(value).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("/DeletePerson")]
        public async Task<ActionResult<Person>> Delete(Int16 Id)
        {
            try
            {
                var person = await _context.People.FirstOrDefaultAsync(x => x.Id == Id);
                if (person == null)
                {
                    return NotFound();
                }
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
