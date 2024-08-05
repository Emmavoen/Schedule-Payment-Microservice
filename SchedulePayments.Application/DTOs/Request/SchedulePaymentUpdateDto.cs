using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulePayments.Application.DTOs.Request
{
    public class SchedulePaymentUpdateDto
    {
        public string Id { get; set; }
        //public string BeneficiaryAccountNumber { get; set; }
        //public string SenderAccountNumber { get; set; }
        public string NoOfPayment { get; set; }
        public string Amount { get; set; }

    }
}