using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchedulePayments.Application.DTOs.Request;
using SchedulePayments.Application.DTOs.Responce;
using SchedulePayments.Application.Helpers;
using SchedulePayments.Domain.Entities;

namespace SchedulePayments.Application.Contracts.Services
{
    public interface ISchedulePaymentService
    {
        Task<SchedulePaymentResponseDetailsDto> CreateSchedulePayment(SchedulePaymentRequestDto requestDto);
        Task<string> DeleteSchedulePayment(string id);
        Task<string> UpdateSchedulePayment(SchedulePaymentUpdateDto request);
         Task<PaginatedList<SchedulePaymentResponseDto>> GetPaginatedSchedulePaymentsBySenderAccountAsync(string senderAccount, int pageNumber, int pageSize);
        
    }
}