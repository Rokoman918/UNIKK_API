using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UNIKK_API.Entities
{
    public class Unity
    {
        public Int64 Id { get; set; }
        public string Code { get; set; }
        [Required]
        public int IdEnterprice { get; set; }
        [Required]
        public int IdtypeUnity { get; set; }


        //public Enterprice enterpriceNav { get; set; }
       
        //public TypeUnity typeUnityNav { get; set; }


        public List<Person> People { get; set; }

    }
}
