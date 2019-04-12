using HealthCatalystPeopleSearchApp.EntityFramework.Models;
using HealthCatalystPeopleSearchApp.Repository;
using HealthCatalystPeopleSearchApp.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace HealthCatalystPeopleSearchApp.Controllers.Tests
{
    [TestClass()]
    public class PeopleControllerTests
    {
        private PeopleController _controller;
        private readonly Mock<IPeopleRepository> _PeopleRepository;

        public PeopleControllerTests()
        {
            _PeopleRepository = new Mock<IPeopleRepository>();
        }

        [TestMethod()]
        public void GetTest()
        {
            //Arrange
            _controller = new PeopleController(_PeopleRepository.Object);
            var people = DataRepoUtility.GetPeople();
            _PeopleRepository.Setup(repo => repo.GetPersonList()).Returns(people);

            //Act
            List<Person> result = _controller.Get().ToList();
            
            //Verify
            _PeopleRepository.Verify(s => s.GetPersonList(), Times.Exactly(1));

            //Assert
            Assert.AreEqual(result.Count, people.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            _controller = new PeopleController(_PeopleRepository.Object);
            Person person = new Person();

            //Act
            _controller.Add(person);

            //Verify
            _PeopleRepository.Verify(s => s.AddPerson(It.IsAny<Person>()), Times.Exactly(1));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Arrange
            _controller = new PeopleController(_PeopleRepository.Object);
            int id = 1;

            //Act
            _controller.Delete(id);

            //Verify
            _PeopleRepository.Verify(s => s.DeletePerson(It.Is<int>(personId => personId == id)), Times.Exactly(1));
        }

        [TestMethod()]
        public void SearchTest_Finds_Match()
        {
            //Arrange
            _controller = new PeopleController(_PeopleRepository.Object);
            string searchStr = "dimebag";
            var people = DataRepoUtility.GetPeople();
            _PeopleRepository.Setup(repo => repo.SearchPeople(searchStr)).Returns(people.Where(p => p.FirstName == searchStr));

            //Act
            List<Person> result = _controller.Search(searchStr).ToList();

            //Verify
            _PeopleRepository.Verify(s => s.SearchPeople(It.Is<string>(searchString => searchString == searchStr)), Times.Exactly(1));

            //Assert
            Assert.AreEqual(result.Count, 1); 
        }

        [TestMethod()]
        public void SearchTest_Does_Not_Find_Match()
        {
            //Arrange
            _controller = new PeopleController(_PeopleRepository.Object);
            string searchStr = "asdlkasjlkdjas";
            var people = DataRepoUtility.GetPeople();
            _PeopleRepository.Setup(repo => repo.SearchPeople(searchStr)).Returns(people.Where(p => p.FirstName == searchStr));

            //Act
            List<Person> result = _controller.Search(searchStr).ToList();

            //Verify
            _PeopleRepository.Verify(s => s.SearchPeople(It.Is<string>(searchString => searchString == searchStr)), Times.Exactly(1));

            //Assert
            Assert.AreEqual(result.Count, 0);
        }
    }
}