using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AtoVen_WebAPI.Models;

namespace AtoVen_WebAPI.Data
{
    public class AtoVen_WebAPIContext : DbContext
    {
        public AtoVen_WebAPIContext (DbContextOptions<AtoVen_WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AtoVen_WebAPI.Models.CompInformation> CompInformation { get; set; }

        public DbSet<AtoVen_WebAPI.Model.BankInformation> BankInformation { get; set; }

        public DbSet<AtoVen_WebAPI.Model.ContactInformation> ContactInformation { get; set; }
    }
}
