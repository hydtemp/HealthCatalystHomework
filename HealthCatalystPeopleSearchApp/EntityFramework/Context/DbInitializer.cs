using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace HealthCatalystPeopleSearchApp.EntityFramework.Context
{
    public class DbInitializer : DropCreateDatabaseAlways<PeopleDbContext>
    {
        protected override void Seed(PeopleDbContext context)
        {   
            context.Person.Add(new Models.Person() { FirstName = "Trent", LastName = "Reznor", Age = 55, Interests = "Rocking out", Address = new Models.Address() { StreetAddress = "1 wallaby way", City = "Cleveland", Country = "USA", ZipCode = "123456", State = "Ohio" }, Image = File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/App_Data/seed_images/trent.jfif")) });
            context.Person.Add(new Models.Person() { FirstName = "Dimebag", LastName = "Darrell", Age = 50, Interests = "Meeting God", Address = new Models.Address() { StreetAddress = "1 wallaby way", City = "Dallas", Country = "USA", ZipCode = "123456", State = "Texas" }, Image = File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/App_Data/seed_images/dimebag.jfif")) });
            context.Person.Add(new Models.Person() { FirstName = "Eddie", LastName = "Vedder", Age = 55, Interests = "Politics", Address = new Models.Address() { StreetAddress = "1 wallaby way", City = "Seattle", Country = "USA", ZipCode = "123456", State = "Washington" }, Image = File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/App_Data/seed_images/eddie.jfif")) });
            context.Person.Add(new Models.Person() { FirstName = "Kurt", LastName = "Cobain", Age = 55, Interests = "Smoking in heaven", Address = new Models.Address() { StreetAddress = "1 wallaby way", City = "Seattle", Country = "USA", ZipCode = "123456", State = "Washington" }, Image = File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/App_Data/seed_images/kurt.jfif")) });
            context.Person.Add(new Models.Person() { FirstName = "Maynard James", LastName = "Keenan", Age = 55, Interests = "Wine making", Address = new Models.Address() { StreetAddress = "1 wallaby way", City = "Los Angeles", Country = "USA", ZipCode = "123456", State = "California" }, Image = File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/App_Data/seed_images/maynard.jfif")) });
            context.Person.Add(new Models.Person() { FirstName = "Thom", LastName = "Yorke", Age = 55, Interests = "Tea", Address = new Models.Address() { StreetAddress = "1 wallaby way", City = "London", Country = "UK", ZipCode = "123456", State = "England" }, Image = File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/App_Data/seed_images/thom.jfif")) });
            context.Person.Add(new Models.Person() { FirstName = "Layne", LastName = "Staley", Age = 55, Interests = "Farming in heaven", Address = new Models.Address() { StreetAddress = "1 wallaby way", City = "Seattle", Country = "USA", ZipCode = "123456", State = "Washington" }, Image = File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/App_Data/seed_images/layne.jfif")) });
            base.Seed(context);
        }
    }
}