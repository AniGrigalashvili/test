﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace test
{
    public class Students
    {

            [Key] public int StudentId  { get; set; }

            public string F_Name { get; set; }

            public string L_Name { get; set; }

            public DateTime BirthDate { get; set; }

            public string Phone { get; set; }       
        
    }
}
