using HealthCatalystPeopleSearchApp.EntityFramework.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCatalystPeopleSearchApp.Tests.Common
{
    public static class DataRepoUtility
    {
        public static List<Person> GetPeople()
        {
            var people = new List<Person>();
            people.Add(GetPerson("dimebag", "darrell"));
            people.Add(GetPerson("trent", "reznor"));
            people.Add(GetPerson("maynard james", "keenan"));
            people.Add(GetPerson("kurt", "cobain"));
            people.Add(GetPerson("thom", "yorke"));
            return people;
        }

        public  static Person GetPerson(string firstName, string lastName)
        {
            Person person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = 55,
                Image = new byte[] { 0x1 },
                Interests = "kayaking",
                Address = new Address()
                {
                    StreetAddress = "teststreetaddress",
                    City = "dallas",
                    State = "texas",
                    ZipCode = "12345",
                    Country = "USA"
                }
            };
            return person;
        }

        public static void ComparePersons(Person p1, Person p2)
        {
            Assert.AreEqual(p1.FirstName, p2.FirstName);
            Assert.AreEqual(p1.LastName, p2.LastName);
            Assert.AreEqual(p1.Age, p2.Age);
            Assert.AreEqual(p1.Interests, p2.Interests);
            Assert.AreEqual(p1.Address.StreetAddress, p2.Address.StreetAddress);
            Assert.AreEqual(p1.Address.City, p2.Address.City);
            Assert.AreEqual(p1.Address.State, p2.Address.State);
            Assert.AreEqual(p1.Address.ZipCode, p2.Address.ZipCode);
            Assert.AreEqual(p1.Address.Country, p2.Address.Country);
        }
    }
}
