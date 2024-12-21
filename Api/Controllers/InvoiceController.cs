using Business_Layer.DTOS;
using Business_Layer.Services;
using DataAccess.Constants;
using DataAccess.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            this._invoiceService = invoiceService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<GenralResponce>> GetAll()
        {
            var rooms = await _invoiceService.GetAll();
            return new GenralResponce { Data = rooms };

        }

        [HttpGet("Invoice Deatils")]
        public async Task<ActionResult<GenralResponce>> GetById(string id)
        {
            return new GenralResponce { Data = await _invoiceService.GetByIdAsync(id) };
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<GenralResponce>> Delete(string id)
        {
            await _invoiceService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("Add")]
        public async Task<ActionResult<GenralResponce>> Add(InvoiceDto dto)
        {
            if (ModelState.IsValid)
            {

                await _invoiceService.AddAsync(dto);
                return CreatedAtAction("GetById", dto);
            }
            return Ok(ModelState);
        }


        [HttpPut("Edit")]
        public async Task<ActionResult<GenralResponce>> Edit(InvoiceDto dto)
        {
            await _invoiceService.EditAsync(dto);
            return NoContent();
        }
    }
}
