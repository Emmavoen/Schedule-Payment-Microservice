using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SchedulePayments.Application.Contracts.Services;
using SchedulePayments.Application.Services;



namespace SchedulePayments.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection RegisterApplicationService(this IServiceCollection services)
        {

            return services
                     .AddTransient<ISchedulePaymentService, SchedulePaymentService>()
                     ;
        }
    }
}
