using Microsoft.EntityFrameworkCore;
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
        public IQueryable<Student_Employment> GetEmployees()
        {
            IQueryable<Student_Employment> employees = context.Employees.Include(b => b.Student).Include(x => x.Supervisor).Include(x => x.Course).Include(x => x.Position);
            foreach( Student_Employment s in employees)
            {
                s.ProgramYear = context.ProgramYears.Where(x => x.ProgramID == s.ProgramID).First();
                s.Semester_Year = context.SemesterYears.Where(x => x.SemesterYearID == s.SemesterYearID).First();
            }
            return employees; 
        }

        public IQueryable<Alert> GetAlerts()
        {
            var now = DateTime.Now; 
            IQueryable<Alert> alerts = context.Alerts.Include(x => x.Student_Employment).Where(x => x.StartAlert > now);

            return alerts;
        }


        public IQueryable<Alert> Alerts => context.Alerts;
        public IQueryable<Course> Course => context.Courses;
        public IQueryable<Position> Positions => context.Positions;
        public IQueryable<ProgramYear> ProgramYears => context.ProgramYears;
        public IQueryable<Semester_Year> SemesterYears => context.SemesterYears;
        public IQueryable<Supervisor> Supervisors => context.Supervisors;


        public void CreateAlert(Alert alert)
        {
            context.Add(alert);
            context.SaveChanges();
        }

        public void CreateStudentEmployee(Student_Employment student)
        {
            IQueryable<Student> test = context.Students.Where(x => x.BYUID == student.BYUID);
            if (test.Count() != 0)
            {
                student.Student = test.FirstOrDefault();
            }
            student.BYUID = student.Student.BYUID;
            student.ProgramYear = context.ProgramYears.Where(x => x.ProgramID == student.ProgramID).FirstOrDefault();
            student.Semester_Year = context.SemesterYears.Where(x => x.SemesterYearID == student.SemesterYearID).FirstOrDefault();

            context.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudentEmployee(Student_Employment student)
        {
            context.Employees.Remove(student);
            context.SaveChanges();
        }

        public void ResolveAlert(Alert alert)
        {
            alert.Completed = true;
            context.SaveChanges();
        }

        public void EditStudentEmployee(Student_Employment student)
        {
            context.Update(student.Student);
            student.BYUID = student.Student.BYUID;
            context.Update(student);
            context.SaveChanges();
        }

        public void FilterStudentList(int supervisorid, int semesteryearid)
        {
            throw new NotImplementedException();
        }
    }
}
