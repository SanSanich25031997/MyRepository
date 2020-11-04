using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required, MinLength(1), MaxLength(100)]
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int BorrowerId { get; set; }
        public virtual Customer Borrower { get; set; }
    }
}
