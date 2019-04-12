using HealthCatalystPeopleSearchApp.EntityFramework.Context;
using HealthCatalystPeopleSearchApp.EntityFramework.Models;
using HealthCatalystPeopleSearchApp.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthCatalystPeopleSearchApp.Repository.Tests
{
    [TestClass()]
    public class PeopleRepositoryIntegTests
    {
        private IPeopleRepository _PeopleRepository;
        private readonly IPeopleDbContext _PeopleDbContext;

        public PeopleRepositoryIntegTests()
        {
            _PeopleDbContext = new PeopleDbContext();
        }

        [TestMethod()]
        public void AddPersonTest()
        {
            try
            {
                //Arrange
                _PeopleRepository = new PeopleRepository(_PeopleDbContext);
                Person person = DataRepoUtility.GetPerson("bob", "williams");

                //Execute
                _PeopleRepository.AddPerson(person);

                //Assert
                Person dbPerson = _PeopleDbContext.Person.Where(p => p.FirstName == person.FirstName).FirstOrDefault();
                DataRepoUtility.ComparePersons(person, dbPerson);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //Clean-up
                Person dbPerson = _PeopleDbContext.Person.Where(p => p.FirstName == "bob").FirstOrDefault();
                if (dbPerson != null)
                {
                    _PeopleDbContext.Person.Remove(dbPerson);
                    _PeopleDbContext.CommitChanges();
                }
            }
        }

        [TestMethod()]
        public void GetPersonListTest()
        {
            try
            {
                //Arrange
                _PeopleRepository = new PeopleRepository(_PeopleDbContext);
                Person person1 = DataRepoUtility.GetPerson("bob", "williams");
                Person person2 = DataRepoUtility.GetPerson("john", "riley");

                _PeopleRepository.AddPerson(person1);
                _PeopleRepository.AddPerson(person2);

                //Execute
                IEnumerable<Person> people = _PeopleRepository.GetPersonList();

                //Assert
                Assert.AreEqual(people.Count(), 2);
                DataRepoUtility.ComparePersons(people.Where(p => p.FirstName == "bob").FirstOrDefault(), person1);
                DataRepoUtility.ComparePersons(people.Where(p => p.FirstName == "john").FirstOrDefault(), person2);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //Clean-up
                DeletePerson("bob");
                DeletePerson("John");
            }
        }

        [TestMethod()]
        public void SearchPeopleTest()
        {
            try
            {
                //Arrange
                _PeopleRepository = new PeopleRepository(_PeopleDbContext);
                Person person1 = DataRepoUtility.GetPerson("bob", "williams");
                Person person2 = DataRepoUtility.GetPerson("john", "riley");

                _PeopleRepository.AddPerson(person1);
                _PeopleRepository.AddPerson(person2);

                //Execute
                IEnumerable<Person> people = _PeopleRepository.SearchPeople("bob"); //search for bob

                //Assert
                Assert.AreEqual(people.Count(), 1); //should only be one person matching
                DataRepoUtility.ComparePersons(people.Where(p => p.FirstName == "bob").FirstOrDefault(), person1);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //Clean-up
                DeletePerson("bob");
                DeletePerson("John");
            }
        }

        [TestMethod()]
        public void SearchPeopleTest_No_Match()
        {
            try
            {
                //Arrange
                _PeopleRepository = new PeopleRepository(_PeopleDbContext);
                Person person1 = DataRepoUtility.GetPerson("bob", "williams");
                Person person2 = DataRepoUtility.GetPerson("john", "riley");

                _PeopleRepository.AddPerson(person1);
                _PeopleRepository.AddPerson(person2);

                //Execute
                IEnumerable<Person> people = _PeopleRepository.SearchPeople("asdasdddasd"); //search for non-existent person

                //Assert
                Assert.AreEqual(people.Count(), 0); //no matches
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //Clean-up
                DeletePerson("bob");
                DeletePerson("John");
            }
        }

        [TestMethod()]
        public void SearchPeopleTest_Empty_Search_String()
        {
            try
            {
                //Arrange
                _PeopleRepository = new PeopleRepository(_PeopleDbContext);
                Person person1 = DataRepoUtility.GetPerson("bob", "williams");
                Person person2 = DataRepoUtility.GetPerson("john", "riley");

                _PeopleRepository.AddPerson(person1);
                _PeopleRepository.AddPerson(person2);

                //Execute
                IEnumerable<Person> people = _PeopleRepository.SearchPeople(""); //search for empty string

                //Assert
                Assert.AreEqual(people.Count(), 2); //should get all people
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //Clean-up
                DeletePerson("bob");
                DeletePerson("John");
            }
        }

        [TestMethod()]
        public void SearchPeopleTest_Null_Search_String()
        {
            try
            {
                //Arrange
                _PeopleRepository = new PeopleRepository(_PeopleDbContext);
                Person person1 = DataRepoUtility.GetPerson("bob", "williams");
                Person person2 = DataRepoUtility.GetPerson("john", "riley");

                _PeopleRepository.AddPerson(person1);
                _PeopleRepository.AddPerson(person2);

                //Execute
                IEnumerable<Person> people = _PeopleRepository.SearchPeople(null); //search for null string

                //Assert
                Assert.AreEqual(people.Count(), 2); //should get all people
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //Clean-up
                DeletePerson("bob");
                DeletePerson("John");
            }
        }

        private void DeletePerson(string firstName)
        {
            Person dbPerson = _PeopleDbContext.Person.Where(p => p.FirstName == firstName).FirstOrDefault();
            if (dbPerson != null)
            {
                _PeopleDbContext.Person.Remove(dbPerson);
                _PeopleDbContext.CommitChanges();
            }
        }
    }
}