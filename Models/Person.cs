using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace UmbracoTutorials.Models
{
    [TableName("Person")]
    public class Person
    {
        public Person()
        {

        }

        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}