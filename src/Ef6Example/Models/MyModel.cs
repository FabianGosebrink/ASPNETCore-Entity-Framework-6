using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ef6Example.Models
{
    public class MyModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
