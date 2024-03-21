using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.DataAccess.ApplicationDataBaseContext;
using PaymentAPI.DataAccess.Repos.Interfaces;
using PaymentAPI.DataAccess.Services;
using PaymentAPI.Models;
using PaymentAPI.Models.DTOs;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {

        private readonly IPaymentDetailsService _paymentDetailsService;

        public PaymentDetailsController(
            [FromKeyedServices("PaymentDetailsService")]IPaymentDetailsService paymentDetailsService
            )
        {
            _paymentDetailsService = paymentDetailsService; 
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PaymentDetailsGetDTO>>> GetPaymentDetails()
        {
            var paymentDetailsDTO = await _paymentDetailsService.GetAllElements();
            return Ok(paymentDetailsDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<IEnumerable<PaymentDetailsGetDTO>>> GetPaymentById(int? id)
        {
            var paymentDetailsDTO = await _paymentDetailsService.GetElementById(id);
            return Ok(paymentDetailsDTO);
        }

        [HttpPost("add")]
        public async Task<ActionResult<PaymentDetailsGetDTO>> AddPaymentDetails(PaymentDetailsPostDTO paymentDetailsPostDTO)
        {
            var paymentDetailsDTO = await _paymentDetailsService.AddElement(paymentDetailsPostDTO);
            return paymentDetailsDTO != null ? Ok(paymentDetailsDTO) : BadRequest();
        }

        [HttpPut("update")]
        public async Task<ActionResult<PaymentDetailsGetDTO>> EditPaymentDetails(PaymentDetailsPutDTO paymentDetailsPutDTO)
        {
            var paymentDetailsDTO = await _paymentDetailsService.EditPaymentDetails(paymentDetailsPutDTO);
            return paymentDetailsDTO != null ? Ok(paymentDetailsDTO) : NotFound();
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<PaymentDetailsGetDTO>> DeletePaymentDetails(int? id)
        {
            var paymentDetailsDTO = await _paymentDetailsService.DeleteElement(id);
            return paymentDetailsDTO != null ? Ok(paymentDetailsDTO) : NotFound();
        }



    }
}
