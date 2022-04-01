using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesWebApplication.Model;

namespace AndreAirLinesWebApplication.Data
{
    public class AndreAirLinesWebApplicationContext : DbContext
    {
        public AndreAirLinesWebApplicationContext (DbContextOptions<AndreAirLinesWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<AndreAirLinesWebApplication.Model.Passageiro> Passageiros { get; set; }

        public DbSet<AndreAirLinesWebApplication.Model.Endereco> Endereco { get; set; }

        public DbSet<AndreAirLinesWebApplication.Model.Aeroporto> Aeroporto { get; set; }

        public DbSet<AndreAirLinesWebApplication.Model.Aeronave> Aeronave { get; set; }

        public DbSet<AndreAirLinesWebApplication.Model.Voo> Voo { get; set; }
    }
}
