using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchedulePayments.Application.Contracts.Repository;
using SchedulePayments.Application.Contracts.Services;
using SchedulePayments.Application.DTOs.Request;
using SchedulePayments.Application.DTOs.Responce;
using SchedulePayments.Application.Helpers;
using SchedulePayments.Domain.Entities;

namespace SchedulePayments.Application.Services
{
    public class SchedulePaymentService : ISchedulePaymentService
    {
        private readonly ISchedulePaymentRepository _repository;
        public SchedulePaymentService(ISchedulePaymentRepository repository)
        {
            _repository = repository;
        }



        public async Task<SchedulePaymentResponseDetailsDto> CreateSchedulePayment(SchedulePaymentRequestDto requestDto)
        {
            var exist = await _repository.ExistAsync(requestDto);
            if (exist)
            {
                return new SchedulePaymentResponseDetailsDto
                {
                    Message = "A schedule payment with the same details already exist",
                    IsSucess = false
                };

            }


            var newSchedulePayment = new SchedulePayment()
            {
                Amount = requestDto.Amount,
                BeneficiaryAccountNumber = requestDto.BeneficiaryAccountNumber,
                BeneficiaryName = requestDto.BeneficiaryName,
                DateCreated = DateTime.Now.ToString("yyyy-MM-dd"),
                DateUpdated = DateTime.Now.ToString("yyyy-MM-dd"),
                EndDate = CalculateEndDate.CalculateEndDateAsync(requestDto.StartDate, requestDto.NoOfPayment, requestDto.PaymentFrequency),
                Narration = requestDto.Narration,
                NoOfPayment = requestDto.NoOfPayment,
                PaymentFrequency = requestDto.PaymentFrequency,
                SenderAccount = requestDto.SenderAccount,
                SenderName = requestDto.SenderName,
                StartDate = requestDto.StartDate,

            };

            var responce = new SchedulePaymentResponseDto()
            {
                BeneficiaryName = newSchedulePayment.BeneficiaryName,
                BeneficiaryAccountNumber = newSchedulePayment.BeneficiaryAccountNumber,
                SenderName = newSchedulePayment.SenderName,
                SenderAccount = newSchedulePayment.SenderAccount,
                Amount = newSchedulePayment.Amount,
                Narration = newSchedulePayment.Narration,
                NoOfPayment = newSchedulePayment.NoOfPayment,
                PaymentFrequency = newSchedulePayment.PaymentFrequency,
                StartDate = newSchedulePayment.StartDate,
                EndDate = newSchedulePayment.EndDate,
                DateCreated = newSchedulePayment.DateCreated,
            };
            await _repository.AddAsync(newSchedulePayment);

            return new SchedulePaymentResponseDetailsDto
            {
                Message = " schedule payment successfully created",
                IsSucess = true,
                ResponceMessage = responce
            };


        }

        public async Task<string> DeleteSchedulePayment(string id)
        {
            var schedulePayment = await _repository.GetByIdAsync(id);
            if (schedulePayment == null)
            {
                return "Invalid details";
            }
            await _repository.DeleteAsync(id);
            return "Successfull";
        }

        public async Task<string> UpdateSchedulePayment(SchedulePaymentUpdateDto request)
        {
            var userExist = await _repository.GetByIdAsync(request.Id);
            if (userExist == null)
            {
                return "Schedule Payment doesnt Exist";
            }

            userExist.Amount = request.Amount;
            userExist.NoOfPayment = request.NoOfPayment;
            await _repository.UpdateAsync(userExist);

            return "Success";
        }

        public async Task<PaginatedList<SchedulePaymentResponseDto>> GetPaginatedSchedulePaymentsBySenderAccountAsync(string senderAccount, int pageNumber, int pageSize)
        {
            
            
            return  await _repository.GetPaginatedBySenderAccountAsync(senderAccount, pageNumber, pageSize);

            
        }

    }
}