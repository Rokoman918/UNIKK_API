using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UNIKK_API.Dto
{

    public class LoadDataDto
    {
        public string  code { get; set; }
        public string  name { get; set; }
        public string TypeNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string email { get; set; }
        public Int32 IdCompany { get; set; }

    }
}
