using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public partial class Students
    {
        [Key] public int StudentId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string F_Name { get; internal set; }
    }
}
