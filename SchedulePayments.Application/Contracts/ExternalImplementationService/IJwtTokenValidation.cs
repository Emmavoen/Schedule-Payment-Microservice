using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulePayments.Application.Contracts.ExternalImplementationService
{
    public interface IJwtTokenValidation
    {
        Task<bool> ValidateJwtTokenAsync(string token);
    }
}