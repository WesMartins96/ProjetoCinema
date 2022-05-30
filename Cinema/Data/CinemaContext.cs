using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace Cinema.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext (DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public DbSet<Cinema.Models.Filme> Filme { get; set; }

        public DbSet<Cinema.Models.Sessao> Sessao { get; set; }

        public DbSet<Cinema.Models.Horario> Horario { get; set; }

        public DbSet<Cinema.Models.Compra> Compra { get; set; }

        public DbSet<Cinema.Models.DetalheSessao> DetalheSessao { get; set; }
    }
}
