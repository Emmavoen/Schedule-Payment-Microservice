using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulePayments.Application.DTOs.Responce
{
    public class SchedulePaymentResponseDetailsDto
    {
        public string Message { get; set; }
        public bool IsSucess { get; set; }
        public SchedulePaymentResponseDto ResponceMessage { get; set; }
    }
}