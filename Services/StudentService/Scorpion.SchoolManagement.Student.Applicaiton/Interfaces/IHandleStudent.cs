using Scorpion.SchoolManagement.Student.Domain.DBEntity;

namespace Scorpion.SchoolManagement.Student.Applicaiton.Interfaces
{
    public interface IHandleStudent
    {
        bool CreateStudent(StudentDetails objStudentDetails);
        bool ModifyStudent(StudentDetails objStudentDetails);
    }
}