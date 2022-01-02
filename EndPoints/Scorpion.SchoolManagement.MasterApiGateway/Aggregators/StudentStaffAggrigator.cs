using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace Scorpion.SchoolManagement.MasterApiGateway.Aggregators
{
    public class StudentStaffAggrigator : IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            
            throw new NotImplementedException();
        }
    }
}
