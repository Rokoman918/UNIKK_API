
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




        [HttpPost("/ValidateUser")]
        public async Task<ActionResult<LoginDataDto>> ValidateUserPost([FromBody]LoginDto value)
        {

            try
            {
                var loginData = new LoginDataDto();

                EnterpriceDto datos = new EnterpriceDto();
                if (String.IsNullOrEmpty(value.email.ToString()) || String.IsNullOrEmpty(value.password.ToString()))
                {
                    var mensaje = new EnterpriceDto() { Error = true, Mensaje = "Datos incompletos" };
                    return BadRequest(
                         new LoginDataDto()
                         {
                             LoginData = mensaje
                         });
                }
                Enterprice dt = new Enterprice();
                dt = await _context.Enterprices.FirstOrDefaultAsync(x => x.EmailAdmin == value.email);

                if (dt == null)
                {
                    var mensaje = new EnterpriceDto() { Error = true, Mensaje = "Login Fallido" };
                    return NotFound(
                         new LoginDataDto()
                         {
                             LoginData = mensaje
                         });
                }

                if (dt.PasswordAdmin == value.password)
                {

                    //No usamos el automaper por que el DTO requiere de dos campos adicionales

                    EnterpriceDto ed = new EnterpriceDto();
                    ed.Id = dt.Id;
                    ed.Address = dt.Address;
                    ed.DateIni = dt.DateIni;
                    ed.DaysWorking = dt.DaysWorking;
                    ed.EmailAdmin = dt.EmailAdmin;
                    ed.Tax_Id = dt.Tax_Id;
                    ed.State = dt.State;
                    ed.PhoneAdmin = dt.PhoneAdmin;
                    ed.PasswordAdmin = dt.PasswordAdmin;
                    ed.NameAdmin = dt.NameAdmin;
                    ed.Name = dt.Name;
                    ed.Mensaje = "OK";
                    ed.Error = false;

                    loginData.LoginData = ed;
                    return loginData;
                }
                else
                {
                    var mensaje = new EnterpriceDto() { Error = true, Mensaje = "Login Fallido" };
                    return BadRequest(
                         new LoginDataDto()
                         {
                             LoginData = mensaje
                         });
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
