using System.ComponentModel.DataAnnotations; 

namespace Mission06_Erickson.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; } // Requirement: Use a dropdown in the view [cite: 24]

        public bool? Edited { get; set; } // Requirement: Not required [cite: 26], Yes/No option [cite: 25]

        public string? LentTo { get; set; } // Requirement: Not required [cite: 26]

        [MaxLength(25)] // Requirement: Limited to 25 characters 
        public string? Notes { get; set; } // Requirement: Not required [cite: 26]
    }
}