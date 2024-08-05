using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SchedulePayments.Application.Contracts.ExternalImplementationService;
using SchedulePayments.Infrastructure.ExternalServiceImplementation;

namespace SchedulePayments.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection RegisterInfrastructureService(this IServiceCollection services)
        {

            return services
                     .AddTransient<IJwtTokenValidation, JwtTokenValidation>()
                     ;
        }
    }
}
