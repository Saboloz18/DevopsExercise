﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Person
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
