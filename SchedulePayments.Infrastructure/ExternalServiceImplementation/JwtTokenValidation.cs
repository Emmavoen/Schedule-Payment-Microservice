using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Json;
using SchedulePayments.Application.Contracts.ExternalImplementationService;

namespace SchedulePayments.Infrastructure.ExternalServiceImplementation
{
    public class JwtTokenValidation : IJwtTokenValidation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public JwtTokenValidation(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> ValidateJwtTokenAsync(string token)
        {
            var httpclient = _httpClientFactory.CreateClient();
            var url = $"https://localhost:6001/api/JwtValidation?token={token}";
            var sendToken = await httpclient.PostAsync(url, null);

            if (sendToken.IsSuccessStatusCode)
            {
                // Create the verification token object

                return true;
            }

            // Handle the error appropriately (log, throw exception, etc.)
            return false;
        }
    }
}