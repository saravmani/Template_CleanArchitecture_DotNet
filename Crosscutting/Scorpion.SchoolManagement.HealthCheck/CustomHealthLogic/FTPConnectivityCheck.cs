using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace Scorpion.SchoolManagement.HealthCheck.CustomHealthLogic
{
    public class FTPConnectivityCheck : IHealthCheck
    {
        public FTPConnectivityCheck(string ftpKey)
        {

        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
