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
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpricesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnterpricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/GetEnterpriceList")]
        public async Task<ActionResult<IEnumerable<Enterprice>>> Get()
        {
            return await _context.Enterprices.ToListAsync();
        }
        [HttpGet("/GetEnterpriceById/{id}", Name = "GetEnterpriceById")]
        public async Task<ActionResult<Enterprice>> GetEnterprice(Int16 Id)
        {
            var enterptice = await _context.Enterprices.FirstOrDefaultAsync(x => x.Id == Id);
            if (enterptice == null)
            {
                return NotFound();
            }
            return enterptice;
        }
        [HttpPost("/CreateEnterprice")]
        public async Task<ActionResult> Post([FromBody] Enterprice entity)
        {
            try
            {
                await _context.Enterprices.AddAsync(entity);
                await _context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetEnterpriceById", new { id = entity.Id, entity });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("/UpdateEnterprice")]
        public async Task<ActionResult> Put(Int16 id, [FromBody] Enterprice value)
        {
            try
            {
                if (id != value.Id)
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


        [HttpDelete("/DeleteEnterprice/{id}")]
        public async Task<ActionResult<Enterprice>> Delete(int id)
        {
            var enterprice = await _context.Enterprices.FirstOrDefaultAsync(x => x.Id == id);
            if (enterprice == null)
            {
                return NotFound();
            }
            _context.Enterprices.Remove(enterprice);
            await _context.SaveChangesAsync();
            return enterprice;

        }
    }
}
