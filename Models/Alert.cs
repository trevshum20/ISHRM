using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISHRM.Models
{
    public class Alert
    {
        [Key]
        [Required]
        public int AlertID { get; set; }

        [Required]
        public string AlertName { get; set; }

        [Required]
        public bool Completed { get; set; }

        [Required]
        public DateTime StartAlert { get; set; }
    }
}
