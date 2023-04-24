using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MZumarraga.Models;

namespace MZumarraga.Data
{
    public class MZumarragaContext : DbContext
    {
        public MZumarragaContext (DbContextOptions<MZumarragaContext> options)
            : base(options)
        {
        }

        public DbSet<MZumarraga.Models.MZumarraga> MZumarraga { get; set; } = default!;
    }
}
