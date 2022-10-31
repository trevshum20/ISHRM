using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISHRM.Models
{
    public class EFStudentRepository : IStudentRepository
    {
        private ClassProjectDBContext context { get; set; }
        public EFStudentRepository(ClassProjectDBContext temp)
        {
            context = temp;
        }
        public IQueryable<Student> Students => context.Students;
        public IQueryable<Student_Employment> Employees => context.Employees;
        public IQueryable<Alert> Alerts => context.Alerts;
        public IQueryable<Course> Course => context.Courses;
        public IQueryable<Position> Positions => context.Positions;
        public IQueryable<ProgramYear> ProgramYears => context.ProgramYears;
        public IQueryable<Semester_Year> SemesterYears => context.SemesterYears;
        public IQueryable<Supervisor> Supervisors => context.Supervisors;


        public void CreateStudentEmployee(Student_Employment student)
        {
            context.Add(student.Student);
            context.SaveChanges();
            context.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudentEmployee(Student_Employment student)
        {
            context.Remove(student);
            context.SaveChanges();
        }

        public void EditStudentEmployee(Student_Employment student)
        {
            context.SaveChanges();
        }

        public void FilterStudentList(int supervisorid, int semesteryearid)
        {
            throw new NotImplementedException();
        }
    }
}
