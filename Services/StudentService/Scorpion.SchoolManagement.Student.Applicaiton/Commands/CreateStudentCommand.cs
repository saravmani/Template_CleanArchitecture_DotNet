using MediatR;

namespace Scorpion.SchoolManagement.Student.Applicaiton.Commands
{
    public class CreateStudentCommand : IRequest<int>
    {       
        public int RecordId { get; set; }
        public string StudentName { get; set; }
    }
}