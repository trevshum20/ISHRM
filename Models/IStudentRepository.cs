using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISHRM.Models
{
    public interface IStudentRepository
    {
        IQueryable<Student> Students { get; }
        IQueryable<Student_Employment> GetEmployees();
        IQueryable<Alert> GetAlerts();
        IQueryable<Course> Course { get; }
        IQueryable<Position> Positions { get; }
        IQueryable<ProgramYear> ProgramYears { get; }
        IQueryable<Semester_Year> SemesterYears { get; }
        IQueryable<Supervisor> Supervisors { get; }
        void CreateStudentEmployee(Student_Employment student);
        void EditStudentEmployee(Student_Employment student);
        void DeleteStudentEmployee(Student_Employment student);
        void FilterStudentList(int supervisorid, int semesteryearid);
        void ResolveAlert(Alert alert);
        void CreateAlert(Alert alert);

    }
}
