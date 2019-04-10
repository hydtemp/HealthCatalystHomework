using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HealthCatalystPeopleSearchApp.EntityFramework.Context
{
    public class DbInitializer : DropCreateDatabaseAlways<PeopleDbContext>
    {
        protected override void Seed(PeopleDbContext context)
        {
            context.Person.Add(new Models.Person() { FirstName = "Trent", LastName = "Reznor", Age = 55, Interests = "Rocking out, Shredding", Address = new Models.Address() { StreetAddress = "1 wallaby way", City = "Cleveland", Country = "USA", ZipCode = "123456", State= "Ohio" } });
            base.Seed(context);
        }
    }
}