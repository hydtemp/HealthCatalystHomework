using HealthCatalystPeopleSearchApp.EntityFramework.Models;
using HealthCatalystPeopleSearchApp.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;

namespace HealthCatalystPeopleSearchApp.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController() : base()
        {
            _peopleRepository = new PeopleRepository(new HealthCatalystPeopleSearchApp.EntityFramework.Context.PeopleDbContext());
        }

        public PeopleController(IPeopleRepository peopleRepo) : base()
        {
            _peopleRepository = peopleRepo;
        }

        // GET api/values
        public IEnumerable<Person> Get()
        {
            using (_peopleRepository)
            {
                List<Person> personList = _peopleRepository.GetPersonList().ToList();
                return personList;
            }
        }

        [System.Web.Http.HttpPost]
        public JsonResult Add(Person person)
        {
            using (_peopleRepository)
            {
                _peopleRepository.AddPerson(person);
                return null;
            }
        }

        [System.Web.Http.HttpDelete]
        public JsonResult Delete(int id)
        {
            using (_peopleRepository)
            {
                _peopleRepository.DeletePerson(id);
                return null;
            }
        }

        [System.Web.Http.HttpPost]
        public IEnumerable<Person> Search(string searchString)
        {
            using (_peopleRepository)
            {
                Thread.Sleep(3000); //simulate 3 seconds delay when searching. OK to lock the main thread.
                List<Person> personList = _peopleRepository.SearchPeople(searchString).ToList();
                return personList;
            }
        }
    }
}