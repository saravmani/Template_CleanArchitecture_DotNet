
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scorpion.SchoolManagement.Student.Applicaiton.Interfaces;
using System.Reflection;

namespace Scorpion.SchoolManagement.Student.Applicaiton
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IHandleStudent, HandleStudent>();



            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
