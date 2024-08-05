using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulePayments.Domain.Entities
{
    public class SchedulePayment
    {
        public string Id { get; set; } = DateTime.Now.Ticks.ToString();
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string NoOfPayment { get; set; }
        public string PaymentFrequency { get; set; }
        public string Amount { get; set; }
        public string BeneficiaryAccountNumber { get; set; }
        public string BeneficiaryName {get; set;}
        public string Narration { get; set; }
        public string SenderAccount { get; set; }
        public string SenderName { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
     }
}