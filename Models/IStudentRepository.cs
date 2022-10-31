using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISHRM.Models
{
    public interface IStudentRepository
    {
        void CreateStudentEmployee(Student_Employment student);
        void EditStudentEmployee(Student_Employment student);
        void DeleteStudentEmployee(Student_Employment student);
        void FilterStudentList(int supervisorid, int semesteryearid);

    }
}
