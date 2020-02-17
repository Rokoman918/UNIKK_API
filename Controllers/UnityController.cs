
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNIKK_API.Contexts;
using UNIKK_API.Entities;

namespace UNIKK_API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UnityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UnityController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("/GetUnities")]
        public async Task<ActionResult<IEnumerable<Unity>>> Get()
        {
            try
            {
                return await _context.Unitys.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("/GetUnityById/{IdUnity}", Name = "GetUnityById")]
        public async Task<ActionResult<Unity>> GetUnityById(Int16 Id)
        {
            try
            {
                var unity = await _context.Unitys.FirstOrDefaultAsync(x => x.Id == Id);
                if (unity == null)
                {
                    return NotFound();
                }
                return unity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("/CreateUnity")]
        public async Task<ActionResult> Post([FromBody] Unity entity)
        {
            try
            {
                await _context.Unitys.AddAsync(entity);
                await _context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetUnityById", new { id = entity.Id, entity });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("/UpdateUnity")]
        public async Task<ActionResult> Put(Int16 Id, [FromBody] Unity value)
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


        [HttpDelete("/DeleteUnity")]
        public async Task<ActionResult<Unity>> Delete(Int16 Id)
        {
            try
            {
                var unity = await _context.Unitys.FirstOrDefaultAsync(x => x.Id == Id);
                if (unity == null)
                {
                    return NotFound();
                }
                _context.Unitys.Remove(unity);
                await _context.SaveChangesAsync();
                return unity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
