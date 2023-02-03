using System.ComponentModel.DataAnnotations;

namespace BookSale.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        [Display(Name = "Book Title")]
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "The Title LEngth Should be Between 2 and 20", MinimumLength = 2)]
        public string? Title { get; set; }
        public string? Genre { get; set; }
        //public List<string>? Authors { get; set; }
        [DataType(DataType.Currency)]//also required 
        [Range(1, 100)]
        public double Price { get; set; }
        [Display(Name = "Publish Date")] //view display
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}
