using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UNIKK_API.Entities
{
    public class TypeUnity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Unity> Unities{ get; set; }

    }
}
