
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreEF6Example.Models
{
    public class MyModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
