using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISHRM.Models
{
    public class Supervisor
    {
        [Key]
        [Required]
        public int SupervisorID { get; set; }

        [Required]
        public string SupervisorFirstName { get; set; }

        [Required]
        public string SupervisorLastName { get; set; }
    }
}
