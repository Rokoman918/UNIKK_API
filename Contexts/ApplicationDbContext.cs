using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNIKK_API.Dto;
using UNIKK_API.Entities;

namespace UNIKK_API.Contexts
{
    public class ApplicationDbContext: DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      :base(options)
        {

        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<LoadDataDto>().ToView("GetResidentData");
        }
        public DbSet<Enterprice>Enterprices { get; set; }
        public DbSet<Unity> Unitys{ get; set; }
        public DbSet<TypeUnity> TypeUnities { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }


    }
}
