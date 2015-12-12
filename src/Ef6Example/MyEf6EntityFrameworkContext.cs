using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Ef6Example.Models;

namespace Ef6Example
{
    public class MyEf6EntityFrameworkContext : DbContext
    {
        public DbSet<MyModel> MyModels{ get; set; }

        public MyEf6EntityFrameworkContext(string connectionString) 
            : base(connectionString)
        {
        }
    }
}
