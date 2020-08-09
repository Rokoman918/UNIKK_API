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
    public class PhoneNumberController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PhoneNumberController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("/GetPhonNumbers")]
        public async Task<ActionResult<IEnumerable<PhoneNumber>>> Get()
        {
            try
            {
                return await _context.PhoneNumbers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("/GetPhoneById/{IdUnity}", Name = "GetPhoneById")]
        public async Task<ActionResult<PhoneNumber>> GetUnityById(Int16 Id)
        {
            try
            {
                var phone = await _context.PhoneNumbers.FirstOrDefaultAsync(x => x.Id == Id);
                if (phone == null)
                {
                    return NotFound();
                }
                return phone;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("/CreatePhoneNumber")]
        public async Task<ActionResult> Post([FromBody] PhoneNumber entity)
        {
            try
            {
                await _context.PhoneNumbers.AddAsync(entity);
                await _context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetPhoneById", new { id = entity.Id, entity });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("/UpdatePhone")]
        public async Task<ActionResult> Put(Int16 Id, [FromBody] PhoneNumber value)
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


        [HttpDelete("/DeletePhone")]
        public async Task<ActionResult<PhoneNumber>> Delete(Int16 Id)
        {
            try
            {
                var phone = await _context.PhoneNumbers.FirstOrDefaultAsync(x => x.Id == Id);
                if (phone == null)
                {
                    return NotFound();
                }
                _context.PhoneNumbers.Remove(phone);
                await _context.SaveChangesAsync();
                return phone;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
