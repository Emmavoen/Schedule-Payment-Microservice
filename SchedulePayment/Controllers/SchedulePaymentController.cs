using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using SchedulePayments.Application.Contracts.ExternalImplementationService;
using SchedulePayments.Application.Contracts.Services;
using SchedulePayments.Application.DTOs.Request;
using SchedulePayments.Application.DTOs.Responce;

namespace SchedulePayment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulePaymentController : ControllerBase
    {
        private readonly IJwtTokenValidation _jwtTokenValidation;
        private readonly ISchedulePaymentService _schedulePaymentsService;
        public SchedulePaymentController(ISchedulePaymentService paymentService, IJwtTokenValidation jwtTokenValidation)
        {
            _schedulePaymentsService = paymentService;
            _jwtTokenValidation = jwtTokenValidation;
        }

        [HttpPost]
        [Route("CreateSchedulePayment")]
        public async Task<IActionResult> CreateSchedulePayment(SchedulePaymentRequestDto requestDto)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if(! await _jwtTokenValidation.ValidateJwtTokenAsync(token))
            {
                return Unauthorized();
            }
            var createSchedulePayment = await _schedulePaymentsService.CreateSchedulePayment(requestDto);
            return Ok(createSchedulePayment);
        }

        [HttpDelete]
        [Route("DeleteSchedulePayment")]
        public async Task<IActionResult> DeleteSchedulePayment(string schedulePaymentId)
        {
            //var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
           // if(! await _jwtTokenValidation.ValidateJwtTokenAsync(token))
            //{
            //    return Unauthorized();
           // }
            var deleteSchedulePayment = await _schedulePaymentsService.DeleteSchedulePayment(schedulePaymentId);
            return Ok(deleteSchedulePayment);
        

        [HttpPut]
        [Route("UpdateSchedulePayment")]
        public async Task<string> UpdateSchedulePayment(SchedulePaymentUpdateDto updateDto)
        {
            var deleteSchedulePayment = await _schedulePaymentsService.UpdateSchedulePayment(updateDto);
            return deleteSchedulePayment;
        }

        [HttpGet("GetSchedulePaymentByAccountNumber")]
        public async Task<IActionResult> GetPaginatedSchedulePaymentsBySenderAccount(string senderAccount, int pageNumber = 1, int pageSize = 10)
        {
            var paginatedList = await _schedulePaymentsService.GetPaginatedSchedulePaymentsBySenderAccountAsync(senderAccount, pageNumber, pageSize);
            return Ok(paginatedList);
        }
    }
}