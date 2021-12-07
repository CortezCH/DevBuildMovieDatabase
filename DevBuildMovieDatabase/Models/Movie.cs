using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildMovieDatabase.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; } = 0;

        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(30, ErrorMessage = "Title must be a max of 30 Characters")]
        public string Title { get; set; }
        public string Genre { get; set; }

        [Range(1880, 2021, ErrorMessage = "Year must be between 1880 and 2021")]
        public int Year { get; set; }
        public int RunTime { get; set; }
    }
}
