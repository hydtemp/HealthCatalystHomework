using HealthCatalystPeopleSearchApp.EntityFramework.Models;
using System;
using System.Collections.Generic;

namespace HealthCatalystPeopleSearchApp.Repository
{
    public interface IPeopleRepository : IDisposable
    {
        void AddPerson(EntityFramework.Models.Person person);

        EntityFramework.Models.Person GetPerson(int personId);

        IEnumerable<EntityFramework.Models.Person> GetPersonList();

        void DeletePerson(int personId);

        IEnumerable<Person> SearchPeople(string searchString);
        
    }
}