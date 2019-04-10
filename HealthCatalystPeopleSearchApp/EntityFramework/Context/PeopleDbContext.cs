using System.Data.Entity;
using HealthCatalystPeopleSearchApp.EntityFramework.Models;

namespace HealthCatalystPeopleSearchApp.EntityFramework.Context
{
    public class PeopleDbContext : DbContext, IPeopleDbContext
    {
        public PeopleDbContext() : base("name=PeopleDbContext")
        {
            Database.SetInitializer<PeopleDbContext>(new DbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public int CommitChanges()
        {
            return SaveChanges();
        }

        public DbSet<Models.Person> Person { get; set; }
        public DbSet<Models.Address> Address { get; set; }
    }
}