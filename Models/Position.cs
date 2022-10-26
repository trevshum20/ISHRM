using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISHRM.Models
{
    public class Position
    {
        [Key]
        [Required]
        public int PositionID { get; set; }

        [Required]
        public string PositionName { get; set; }
    }
}
