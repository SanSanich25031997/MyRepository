using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required, MinLength(1), MaxLength(30)]
        public string Name { get; set; }
        [Required, MinLength(1), MaxLength(30)]
        public string LastName { get; set; }
    }
}
