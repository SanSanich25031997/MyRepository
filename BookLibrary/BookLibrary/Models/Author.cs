using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
