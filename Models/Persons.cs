using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
