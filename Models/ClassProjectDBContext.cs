using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISHRM.Models
{
    public class ClassProjectDBContext : DbContext
    {
        public ClassProjectDBContext()
        {
        }

        public ClassProjectDBContext(DbContextOptions<ClassProjectDBContext> options)
            : base(options)
        {
        }

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ProgramYear> ProgramYears { get; set; }
        public DbSet<Semester_Year> SemesterYears { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Student_Employment> Employees {get; set;}

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // on Creating a model, seed these data in the database.
            mb.Entity<Course>().HasData(
                new Course
                {
                    CourseID = 1,
                    CourseCode = "IS201",
                    CourseName = "Intro to IS Course"
                },
                new Course
                {
                    CourseID = 2,
                    CourseCode = "IS303",
                    CourseName = "Javascript Programming"
                },
                new Course
                {
                    CourseID = 3,
                    CourseCode = "IS110",
                    CourseName = "Excel Spreadsheets"
                }
            );
            mb.Entity<Position>().HasData(
                new Position
                {
                    PositionID = 1,
                    PositionName = "RA",
                },
                new Position
                {
                    PositionID = 2,
                    PositionName = "TA",
                },
                new Position
                {
                    PositionID = 3,
                    PositionName = "Office",
                },
                new Position
                {
                    PositionID = 4,
                    PositionName = "Student Instructor",
                },
                new Position
                {
                    PositionID = 5,
                    PositionName = "Other",
                }
            );
            mb.Entity<ProgramYear>().HasData(
                new ProgramYear
                {
                    ProgramID = 1,
                    ProgramName = "MSB Core"
                },
                new ProgramYear
                {
                    ProgramID = 2,
                    ProgramName = "MISM"
                },
                new ProgramYear
                {
                    ProgramID = 3,
                    ProgramName = "MBA"
                },
                new ProgramYear
                {
                    ProgramID = 4,
                    ProgramName = "MPA"
                },
                new ProgramYear
                {
                    ProgramID = 5,
                    ProgramName = "MACC"
                },
                new ProgramYear
                {
                    ProgramID = 6,
                    ProgramName = "Other"
                }

            );
            mb.Entity<Semester_Year>().HasData(
                new Semester_Year
                {
                    SemesterYearID = 1,
                    SemesterName = "Fall",
                    Year = 2021
                },
                new Semester_Year
                {
                    SemesterYearID = 2,
                    SemesterName = "Winter",
                    Year = 2022
                },
                new Semester_Year
                {
                    SemesterYearID = 3,
                    SemesterName = "Spring",
                    Year = 2022
                },
                new Semester_Year
                {
                    SemesterYearID = 4,
                    SemesterName = "Summer",
                    Year = 2022
                },
                new Semester_Year
                {
                    SemesterYearID = 5,
                    SemesterName = "Fall",
                    Year = 2022
                }
            );
            mb.Entity<Supervisor>().HasData(
                new Supervisor
                {
                    SupervisorID = 1,
                    SupervisorFirstName = "Greg",
                    SupervisorLastName = "Anderson"
                },
                new Supervisor
                {
                    SupervisorID =2,
                    SupervisorFirstName = "Gove",
                    SupervisorLastName = "Allen"
                },
                new Supervisor
                {
                    SupervisorID =3,
                    SupervisorFirstName ="Jeff",
                    SupervisorLastName ="Jenkins"
                },
                new Supervisor
                {
                    SupervisorID =4,
                    SupervisorFirstName = "Degan",
                    SupervisorLastName = "Kettles"
                }
             );
        }
    }
}
