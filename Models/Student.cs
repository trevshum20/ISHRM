using System;
using System.ComponentModel.DataAnnotations;

namespace ISHRM.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int BYUID { get; set; }
        public string NetID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool International { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string NetID { get; set; }
        public bool NameChange { get; set; }
        public string Notes { get; set; }
        public string BYUName { get; set; }
    }
}
