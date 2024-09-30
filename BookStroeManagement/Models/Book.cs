using System.ComponentModel.DataAnnotations;

namespace BookStroeManagement.Models
{
    public class Book
    {
        
        public int BookID { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        [StringLength(25)]
        public string Title { get; set; }
        [Required]
        [StringLength(20)]
        public string Author { get; set; }

       [Required(ErrorMessage = "Price is Required")]
        [Range(5, 20, ErrorMessage = "The price should be between 5 and 20")]
        public double Price { get; set; }
        public string Genre { get; set; }

    }
}
