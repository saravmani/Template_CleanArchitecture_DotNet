using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//using Scorpion.SchoolManagement.EmployeeManagement.ApiGrpc;
using Scorpion.SchoolManagement.Employee.ApiGrpc;

using Scorpion.SchoolManagement.Student.Api.ViewModel;
using Scorpion.SchoolManagement.Student.Applicaiton.Commands;
using Scorpion.SchoolManagement.Student.Applicaiton.Interfaces;
using Scorpion.SchoolManagement.Student.Domain.DBEntity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scorpion.SchoolManagement.Student.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IHandleStudent _handleStudent;
        private readonly IMapper _Mapper;
        //private readonly Greeter.GreeterClient _greaterClient;

        public StudentController(IMediator mediator, IHandleStudent handleStudent, IMapper mapper)
        {

            _mediator = mediator;
            _handleStudent = handleStudent;
            _Mapper = mapper;
            //_greaterClient = greaterClient;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public string Get(int id)
        {
            //var response = _greaterClient.SayHello(new HelloRequest { 
            //     Name="ding dong"
            //});
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]

        public void Post(StudentDetailsVm objStudentDetailsVm)
        {

            var objStudentDetailsDTO = _Mapper.Map<StudentDetails>(objStudentDetailsVm);

            //Method-1 - With DI
            this._handleStudent.CreateStudent(objStudentDetailsDTO); ;

            //Method-2 - With MediatR
            var objCreateStudentCommand = _Mapper.Map<CreateStudentCommand>(objStudentDetailsVm);
            //var _newStudentInsertCommand = new CreateStudentCommand();
            //_newStudentInsertCommand.StudentName = objStudentDetails.StudentName;
            _mediator.Send(objCreateStudentCommand);




        }


    }
}
