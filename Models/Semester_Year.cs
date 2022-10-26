using System;
using System.ComponentModel.DataAnnotations;

namespace ISHRM.Models
{
    public class Semester_Year
    {
        [Key]
        [Required]
        public int SemesterYearID { get; set; }
        public string SemesterName { get; set; }
        public int Year { get; set; }
    }
}
