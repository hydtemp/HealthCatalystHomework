using HealthCatalystPeopleSearchApp.EntityFramework.Context;
using HealthCatalystPeopleSearchApp.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HealthCatalystPeopleSearchApp.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IPeopleDbContext _dbContext;

        public PeopleRepository(PeopleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPerson(Person person)
        {
            _dbContext.Person.Add(person);
            _dbContext.CommitChanges();
        }

        public Person GetPerson(int personId)
        {
            Person person = _dbContext.Person.Where(x => x.Id == personId).FirstOrDefault();
            return person;
        }

        public IEnumerable<Person> GetPersonList()
        {
            List<Person> personList = _dbContext.Person.OrderBy(p => p.LastName).Include(p => p.Address).ToList();
            return personList.AsEnumerable();
        }

        public IEnumerable<Person> SearchPeople(string searchString)
        {
            List<Person> persons;

            if (string.IsNullOrEmpty(searchString))
            {
                return GetPersonList();
            }
            else
            {

                persons = _dbContext.Person.Where(p =>
                        (!string.IsNullOrEmpty(p.LastName) && p.LastName.ToLower().Contains(searchString)) ||
                        (!string.IsNullOrEmpty(p.FirstName) && p.FirstName.ToLower().Contains(searchString))
                ).OrderBy(p => p.LastName).Include(p => p.Address).ToList();
            }

            return persons;
        }

        void IPeopleRepository.DeletePerson(int personId)
        {
            var person = GetPerson(personId);
            _dbContext.Person.Remove(person);
            _dbContext.CommitChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}