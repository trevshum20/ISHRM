﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ISHRM.Models
{
    public class Student_Employment
    {
        [Key]
        [Required]
        public int StudentEmploymentID { get; set; }

        // Foreign Key
        [Required]
        public int BYUID { get; set; }

        [Required]
        public int ExpectedHours { get; set; }

        // Foreign Key
        [Required]
        public int SemesterYearID { get; set; }

        // Foreign Key
        [Required]
        public int PositionID { get; set; }

        // Foreign Key
        [Required]
        public int CourseID { get; set; }

        [Required]
        public int EmplRecord { get; set; }

        // Foreign Key
        [Required]
        public int SupervisorID { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public double PayRate { get; set; }

        [Required]
        public DateTime LastPayInc { get; set; }

        [Required]
        public double LastPayIncAmount { get; set; }

        [Required]
        public DateTime PayIncDate { get; set; }

        // Foreign Key
        [Required]
        public int ProgramID { get; set; }

        [Required]
        public bool PayGradTuition { get; set; }

        public string Notes { get; set; }

        [Required]
        public bool Terminated { get; set; }

        public DateTime TerminationStart { get; set; }

        public DateTime QualtricsSent { get; set; }

        public DateTime SubmittedEForm { get; set; }

        public DateTime AuthorizationToWorkRec { get; set; }

        public DateTime AuthorizationEmailSentDate { get; set; }
    }
}