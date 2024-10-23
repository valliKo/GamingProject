using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GamingProject.Model;

namespace GamingProject.Data
{
    public class GamingProjectContext : DbContext
    {
        public GamingProjectContext (DbContextOptions<GamingProjectContext> options)
            : base(options)
        {
        }

        public DbSet<GamingProject.Model.Game> Game { get; set; } 
    }
}
