using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UNIKK_API.Entities
{
    public class Enterprice
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Tax_Id { get; set; }
        public string Address { get; set; }
        public Boolean State { get; set; }

        public List<Unity> Unities{ get; set; }

    }
}
