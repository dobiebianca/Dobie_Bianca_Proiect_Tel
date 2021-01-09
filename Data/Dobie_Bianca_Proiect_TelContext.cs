using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dobie_Bianca_Proiect_Tel.Models;

namespace Dobie_Bianca_Proiect_Tel.Data
{
    public class Dobie_Bianca_Proiect_TelContext : DbContext
    {
        public Dobie_Bianca_Proiect_TelContext (DbContextOptions<Dobie_Bianca_Proiect_TelContext> options)
            : base(options)
        {
        }

        public DbSet<Dobie_Bianca_Proiect_Tel.Models.Phone> Phone { get; set; }

        public DbSet<Dobie_Bianca_Proiect_Tel.Models.Seller> Seller { get; set; }

        public DbSet<Dobie_Bianca_Proiect_Tel.Models.Category> Category { get; set; }
    }
}
