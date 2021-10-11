using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Scorpion.SchoolManagement.Student.Api.ViewModel;
using Scorpion.SchoolManagement.Student.Applicaiton.Commands;
using Scorpion.SchoolManagement.Student.Domain.DBEntity;

namespace Scorpion.SchoolManagement.Student.Api
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<StudentDetails, StudentDetailsVm>().ReverseMap();
            CreateMap<CreateStudentCommand, StudentDetailsVm>().ReverseMap();//For MediatR

            
        }        
    }
}
