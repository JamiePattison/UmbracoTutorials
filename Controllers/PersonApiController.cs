using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbracoTutorials.Models;
using Umbraco.Core.Persistence;
using Umbraco.Web.Editors;

namespace UmbracoTutorials.Controllers
{
    public class PersonApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<Person> GetAll()
        {
            var query = new Sql().Select("*").From("Person");

            return DatabaseContext.Database.Fetch<Person>(query);
        }

        public Person GetById(int id)
        {
            var person = new Sql().Select("*").From("Person").Where<Person>(x=> x.Id==id);
            return DatabaseContext.Database.Fetch<Person>(person).FirstOrDefault();
        }

        public Person PostSave(Person person)
        {
            if (person.Id > 0)
            {
                DatabaseContext.Database.Update(person);
            }
            else
            {
                DatabaseContext.Database.Save(person);
            }

            return person;
        }

        public int DeleteById(int id)
        {
           return DatabaseContext.Database.Delete<Person>(id);
        }
        //private List<Person> GetListofPeople()
        //{
        //    List<Person> peoples = new List<Person>();

        //    var p = new Person
        //    {
        //        Name = "Shelly"
        //    };

        //    peoples.Add(p);

        //    return peoples;
        //}
    }
}