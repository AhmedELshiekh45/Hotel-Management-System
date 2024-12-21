using DataAccess.UOF;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PaymentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Payment
    [HttpGet]
    public async Task<IActionResult> GetAllPayments()
    {
        var payments = await _unitOfWork.PaymentRepo.GetAllAsync();
        return Ok(payments);
    }

    // GET: api/Payment/{id}
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var payment = await _unitOfWork.PaymentRepo.GetByIdAsync(id);
        if (payment == null)
        {
            return NotFound(new { Message = "Payment not found." });
        }
        return Ok(payment);
    }



    // PUT: api/Payment/{id}
    [HttpPut("Update ")]
    public async Task<IActionResult> Update( [FromBody] Payment payment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingPayment = await _unitOfWork.PaymentRepo.GetByIdAsync(payment.Id);
        if (existingPayment == null)
        {
            return NotFound(new { Message = "Payment not found." });
        }
        
        existingPayment.Amount = payment.Amount;
        existingPayment.PaymentMethod = payment.PaymentMethod;

        _unitOfWork.PaymentRepo.Edit(existingPayment);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    // DELETE: api/Payment/{id}
    [HttpDelete(" Delete")]
    public async Task<IActionResult> Delete(string id)
    {
        var payment = await _unitOfWork.PaymentRepo.GetByIdAsync(id);
        if (payment == null)
        {
            return NotFound(new { Message = "Payment not found." });
        }

        _unitOfWork.PaymentRepo.Delete(payment);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}
