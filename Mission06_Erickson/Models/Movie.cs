using System.ComponentModel.DataAnnotations; 

namespace Mission06_Erickson.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int CategoryId { get; set; }
        //navigation property
        public Category? Category { get; set; }

        [Required (ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2026, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }
        
        public string? Director { get; set; }
        
        public string? Rating { get; set; } // Requirement: Use a dropdown in the view [cite: 24]
        
        [Required (ErrorMessage = "Enter whether the movie is edited or not")]
        public bool Edited { get; set; } // Requirement: Not required [cite: 26], Yes/No option [cite: 25]

        public string? LentTo { get; set; } // Requirement: Not required [cite: 26]

        [Required]
        public bool CopiedToPlex { get; set; }
        
        [MaxLength(25)] // Requirement: Limited to 25 characters 
        public string? Notes { get; set; } // Requirement: Not required [cite: 26]
    }
}