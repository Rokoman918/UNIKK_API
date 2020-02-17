using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNIKK_API.Contexts;
using UNIKK_API.Dto;

namespace UNIKK_API.Controllers
{

    [Route("api/controller")]
    [ApiController]
    public class DataManagerController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public DataManagerController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet("/GetResident/{Id}")]
        [Obsolete]
        public async Task<ListofResidents> GetResident(Int32  Id)
        {
            try
            {

                var rlist = new ListofResidents();
                var listResidents = await _context.Query<LoadDataDto>().Where(x => x.IdCompany == Id).ToListAsync();
                rlist.list = listResidents; 

                return rlist;
            }
            catch (Exception  ex)
            {

                throw  ex;
            }
        }
    }
}
