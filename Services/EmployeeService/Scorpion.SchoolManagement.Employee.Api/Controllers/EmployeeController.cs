using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scorpion.SchoolManagement.EmployeeManagement.Api.ViewModel;

namespace Scorpion.SchoolManagement.EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<EmployeeVm> GetEmployeeList()
        {
            return new List<EmployeeVm> {
                new EmployeeVm {
                 EmployeeName="testname1"
            }, new EmployeeVm {
                EmployeeName="testname2"
            }
            };
        }
    }
}
