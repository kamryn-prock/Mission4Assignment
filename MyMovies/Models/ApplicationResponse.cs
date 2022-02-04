using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Models
{
    public class ApplicationResponse
    {
        // category, title, year, director, rating, edited, lent to, notes
        // rating field with a dropdown menu
        // edited field to be yes/no
        // edited, lent to, and notes are optional. Notes limited to 25 characters
        
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public short year { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; } // make a drop down
        public bool edited { get; set; }
        public string lent { get; set; }
        //[Range(0, 25)]
        public string notes { get; set; }// 25 characters

        // Build the Foreign Key relationship
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
       

    }
}
