using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HealthCatalystDemo.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> person { get; set; }
    }

}