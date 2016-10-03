using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthCatalystDemo.Models
{
    
    public class Person
    {
        [Key, Column(Order = 0)]


        public string FirstName { get; set; }
        [Key, Column(Order = 1)]
        public string LastName { get; set; }

        public string Age { get; set; }
        public string Address { get; set; }
        public string Interests { get; set; }
        public byte[] Image { get; set; }
    }
}