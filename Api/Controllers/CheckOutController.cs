using AutoMapper;
using DataAccess.Constants;
using DataAccess.UOF;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe.V2;
using System.Security.Claims;
namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckOutController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        [HttpPost("CreatePayment")]
        public async Task<ActionResult<GenralResponce>> CreatePayment(string invoiceId)
        {


            // Fetch the invoice by ID
            var invoice = await _unitOfWork.InvoiceRepo.GetByIdAsync(invoiceId);

            if (invoice == null)
            {
                return NotFound(new { Message = "Invoice not found." });
            }

            // Create a payment session
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
        {
            new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "usd",
                    UnitAmount = (long)(invoice.TotalAmount * 100), // Stripe accepts amounts in cents
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = $"Invoice #{invoice.Id}"
                    },
                },
                Quantity = 1
            }
        },
                Mode = "payment",
                SuccessUrl = $"{Request.Scheme}://{Request.Host}/checkout/Complete?invoiceId={invoice.Id}",
                CancelUrl = $"{Request.Scheme}://{Request.Host}/checkout/Reject",
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            // Validate the session URL
            if (string.IsNullOrEmpty(session.Url))
            {
                return StatusCode(500, new { Message = "Failed to create Stripe payment session." });
            }




            // Redirect the user to Stripe's hosted checkout page
            return Ok(session.Url);
        }



        [HttpGet("Complete")]
        public async Task<ActionResult<GenralResponce>> CompletePayment([FromQuery] string invoiceid)
        {
            var invoice = await _unitOfWork.InvoiceRepo.GetByIdAsync(invoiceid);
            var payment = new Payment { Amount = invoice.TotalAmount, Invoice = invoice, PaymentMethod = "Stripe", InvoiceId = invoiceid };
            await _unitOfWork.PaymentRepo.AddAsync(payment);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(actionName: "GetById", controllerName: "Payment", routeValues: null, value: new
            {
                Id= payment.Id,
                PaymentMethod=payment.PaymentMethod,
                InvoiceId=payment.InvoiceId,
                Amount = payment.Amount
            });


        }
        [HttpGet("Reject")]
        public async Task<ActionResult<GenralResponce>> RejectPayment()
        {
            // var invoice=await _unitOfWork.InvoiceRepo.GetByIdAsync(invoiceid);
            return NoContent();
        }

    }
}
