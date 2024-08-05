using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulePayments.Application.Helpers
{
    public class CalculateEndDate
    {
        public static string CalculateEndDateAsync(string _startDate, string _numberOfPayments, string paymentFrequency)
        {
            // Convert input strings to appropriate types
            if (!DateTime.TryParse(_startDate, out var startDate))
            {
                throw new ArgumentException("Invalid Start Date");
            }

            if (!int.TryParse(_numberOfPayments, out var numberOfPayments))
            {
                throw new ArgumentException("Invalid Number of Payments");
            }

            var frequency = paymentFrequency.ToLower();
            int interval = frequency == "weekly" ? 7 : (frequency == "daily" ? 1 : throw new ArgumentException("Invalid Payment Frequency"));

            // Calculate end date
            var endDate = startDate.AddDays((numberOfPayments - 1) * interval);

            // Return end date as string
            return endDate.ToString("yyyy-MM-dd");
        }
    }
}