using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchedulePayments.Application.DTOs.Request;
using SchedulePayments.Application.DTOs.Responce;
using SchedulePayments.Application.Helpers;
using SchedulePayments.Domain.Entities;

namespace SchedulePayments.Application.Contracts.Repository
{
    public interface ISchedulePaymentRepository
    {
    
       Task<SchedulePayment> GetByIdAsync(string id);
       Task<List<SchedulePayment>> GetAll();
       Task UpdateAsync(SchedulePayment payment);
       Task DeleteAsync(string id);
       Task AddAsync(SchedulePayment payment);
       Task<bool> ExistAsync(SchedulePaymentRequestDto request);
       Task<PaginatedList<SchedulePaymentResponseDto>> GetPaginatedBySenderAccountAsync(string senderAccount, int pageNumber, int pageSize);
    }
}