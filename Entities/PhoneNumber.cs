using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UNIKK_API.Entities
{
    public class PhoneNumber
    {
        public Int64 Id { get; set; }
        public string Phone { get; set; }
        public string CountryCode { get; set; }
        public string TypeNumber { get; set; }
        public Int64 PersonId { get; set; }


        public Person PersonNav { get; set; }
    }
}
