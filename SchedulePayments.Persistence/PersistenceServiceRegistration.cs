using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchedulePayments.Application.Contracts.Repository;
using SchedulePayments.Persistence.DatabaseContext;
using SchedulePayments.Persistence.RepositoryImplementation;

namespace SchedulePayments.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection RegisterPersistenceService(this IServiceCollection services, IConfiguration conn)
        {

           return  services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    conn.GetConnectionString("Conn")))
                    .AddTransient<ISchedulePaymentRepository, SchedulePaymentRepository>()
                    ;
        }
        
    }
}
