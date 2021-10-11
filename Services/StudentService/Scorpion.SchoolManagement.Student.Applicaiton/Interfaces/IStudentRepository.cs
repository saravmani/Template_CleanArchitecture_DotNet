using System;
using System.Collections.Generic;
using System.Text;
using Scorpion.SchoolManagement.Common.Infra.Persister;
using Scorpion.SchoolManagement.Student.Domain.DBEntity;

namespace Scorpion.SchoolManagement.Student.Applicaiton.Interfaces
{
    public interface IStudentRepository : IAsyncRepository<StudentDetails>
    {

    }
}
