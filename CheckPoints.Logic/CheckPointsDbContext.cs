using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CheckPoints.Logic
{
    public class CheckPointsDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }

        public DbSet<CheckPoint> CheckPoints { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Record> Journal { get; set; }

        public CheckPointsDbContext() : base("CheckPointsContext")
        {
            Database.SetInitializer<CheckPointsDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
