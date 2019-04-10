using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCatalystPeopleSearchApp.EntityFramework.Context
{
    public interface IPeopleDbContext : IDisposable
    {
        DbSet<Models.Person> Person { get; set; }
        DbSet<Models.Address> Address { get; set; }
        int CommitChanges();
    }
}
