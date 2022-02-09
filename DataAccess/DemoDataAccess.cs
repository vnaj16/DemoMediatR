using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<Person> people = new();

        public DemoDataAccess()
        {
            people.Add(new Person() { Id = 1, FirstName = "Arthur", LastName = "Valladares" });
            people.Add(new Person() { Id = 2, FirstName = "Javier", LastName = "Nole" });
        }

        public List<Person> GetPeople()
        {
            return people;
        }

        public Person InsertPerson(string firstName, string lastName)
        {
            Person person = new Person()
            {
                FirstName = firstName,
                LastName = lastName
            };
            person.Id = people.Max(x => x.Id) + 1;
            people.Add(person);

            return person;
        }
    }
}
