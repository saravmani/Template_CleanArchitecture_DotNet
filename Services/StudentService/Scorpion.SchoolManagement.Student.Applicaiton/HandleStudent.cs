using System;
using System.Collections.Generic;
using System.Text;
using Scorpion.SchoolManagement.Student.Applicaiton.Interfaces;
using Scorpion.SchoolManagement.Student.Domain.DBEntity;

namespace Scorpion.SchoolManagement.Student.Applicaiton
{
    internal class HandleStudent : IHandleStudent
    {
        private readonly IStudentRepository studentRepository;
        public HandleStudent(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
            //this.mapper = mapper;
        }

        public bool CreateStudent(StudentDetails objStudentDetails)
        {
            studentRepository.AddAsync(objStudentDetails).Wait();
            //return studentId.RecordId;
            return true;

        }
        public bool ModifyStudent(StudentDetails objStudentDetails)
        {
            return true;

        }
    }
}
