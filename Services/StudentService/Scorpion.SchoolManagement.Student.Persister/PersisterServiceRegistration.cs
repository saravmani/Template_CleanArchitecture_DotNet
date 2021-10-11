
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scorpion.SchoolManagement.Student.Applicaiton.Interfaces;
using Scorpion.SchoolManagement.Student.Persister;
using System.Reflection;

namespace Scorpion.SchoolManagement.Student.Applicaiton
{
    public static class PersisterServiceRegistration
    {
        public static IServiceCollection AddPersisterServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudentManagerContext>();
            return services;
        }
    }
}
