using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using EvolutionSimulator.Models;

namespace EvolutionSimulator.DAL
{
    public class MapRepositoryCodeFirst : DbContext
    {
            public DbSet<MapMatrix> MapMatrixes { get; set; }
            public DbSet<Ground> Grounds { get; set; }
            public DbSet<Plant> Plants { get; set; }
            public DbSet<DNA> DNAs { get; set; }

    }
}
