using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scorpion.SchoolManagement.Student.Applicaiton.Interfaces;
using Scorpion.SchoolManagement.Student.Domain.DBEntity;

namespace Scorpion.SchoolManagement.Student.Applicaiton.Commands
{
    public class CreateStudent : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository studentRepository;
        //private readonly IMapper mapper;

        public CreateStudent(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
            //this.mapper = mapper;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            //var stdlist = await studentRepository.GetAllAsync();
            var studentId = await studentRepository.AddAsync(new StudentDetails { StudentName = request.StudentName });
            return studentId.RecordId;
        }
    }
}
