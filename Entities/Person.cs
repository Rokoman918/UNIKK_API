using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UNIKK_API.Entities
{
    public class Person
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Int64 UnityId { get; set; } 
        
        public Unity IdUnityNav { get; set; }
      
        public List<PhoneNumber>  Phones {get; set;}
    }
}
