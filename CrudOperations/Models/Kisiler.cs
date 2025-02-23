using System.ComponentModel.DataAnnotations;

namespace CrudOperations.Models
{
    public class Kisiler
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }

    }
}
