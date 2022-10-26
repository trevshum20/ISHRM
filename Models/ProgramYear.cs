using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISHRM.Models
{
    public class ProgramYear
    {
            [Key]
            [Required]
            public int ProgramID { get; set; }

            [Required]
            public string ProgramName { get; set; }
    }
}
