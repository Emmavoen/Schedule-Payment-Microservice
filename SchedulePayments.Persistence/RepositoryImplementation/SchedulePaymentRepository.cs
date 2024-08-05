using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulePayments.Application.Contracts.Repository;
using SchedulePayments.Application.DTOs.Request;
using SchedulePayments.Application.DTOs.Responce;
using SchedulePayments.Application.Helpers;
using SchedulePayments.Domain.Entities;
using SchedulePayments.Persistence.DatabaseContext;

namespace SchedulePayments.Persistence.RepositoryImplementation
{
    public class SchedulePaymentRepository : ISchedulePaymentRepository
    {
        private readonly AppDbContext _appDbContext;
        public SchedulePaymentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task<List<SchedulePayment>> GetAll()
        {
            return await _appDbContext.SchedulePayments.ToListAsync();

        }

        public async Task<SchedulePayment> GetByIdAsync(string id)
        {
            return await _appDbContext.SchedulePayments.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task UpdateAsync(SchedulePayment payment)
        {
            _appDbContext.SchedulePayments.Update(payment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var result = await _appDbContext.SchedulePayments.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.SchedulePayments.Remove(result);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task AddAsync(SchedulePayment payment)
        {
            await _appDbContext.SchedulePayments.AddAsync(payment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(SchedulePaymentRequestDto request)
        {
            return await _appDbContext.SchedulePayments.AnyAsync(sp =>
            sp.StartDate == request.StartDate &&
            sp.Amount == request.Amount &&
            sp.BeneficiaryAccountNumber == request.BeneficiaryAccountNumber &&
            sp.SenderAccount == request.SenderAccount);
        }

        public async Task<PaginatedList<SchedulePaymentResponseDto>> GetPaginatedBySenderAccountAsync(string senderAccount, int pageNumber, int pageSize)
        {
            var query = _appDbContext.SchedulePayments.Where(sp => sp.SenderAccount == senderAccount).AsQueryable();
            var count = await query.CountAsync();

            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();


            var dtoItems = items.Select(sp => new SchedulePaymentResponseDto
                                   {
                                       
                                       StartDate = sp.StartDate,
                                       EndDate = sp.EndDate,
                                       NoOfPayment = sp.NoOfPayment,
                                       PaymentFrequency = sp.PaymentFrequency,
                                       Amount = sp.Amount,
                                       BeneficiaryAccountNumber = sp.BeneficiaryAccountNumber,
                                       BeneficiaryName = sp.BeneficiaryName,
                                       Narration = sp.Narration,
                                       SenderAccount = sp.SenderAccount,
                                       SenderName = sp.SenderName,
                                       DateCreated = sp.DateCreated,
                                       DateUpdated = sp.DateUpdated
                                    }).ToList();

            return new PaginatedList<SchedulePaymentResponseDto>(dtoItems, count, pageNumber, pageSize);
        }


    }
}