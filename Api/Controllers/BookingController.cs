using Business_Layer.DTOS;
using Business_Layer.Services;
using DataAccess.Constants;
using DataAccess.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            this._bookingService = bookingService;
        }


        private async Task<string?> GetUserId()
        { // Retrieve the user ID from the JWT token claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return null;
            }
            return (userId);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<GenralResponce>> GetAll()
        {
            return new GenralResponce { Data = await _bookingService.GetAllAsync() };
        }

        [HttpGet("GetDeatils")]
        public async Task<ActionResult<GenralResponce>> GetById(string id)
        {
            return new GenralResponce { Data = await _bookingService.GetRoomDeatils(id) };
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<ActionResult<GenralResponce>> Add(BookingDto bookingDto)
        {
            if (ModelState.IsValid)
            {
                bookingDto.GustId = await GetUserId();
                await _bookingService.AddAsync(bookingDto);
                return CreatedAtAction("GetById", bookingDto);
            }
            return BadRequest(ModelState);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpPut("Edit")]
        public async Task<ActionResult<GenralResponce>> Edit(BookingDto bookingDto)
        {
            if (ModelState.IsValid)
            {
                bookingDto.GustId = await GetUserId();
                await _bookingService.EditAsync(bookingDto);
                return CreatedAtAction("GetById", bookingDto);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public async Task<ActionResult<GenralResponce>> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.DeleteAsync(id);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Order Service")]
        public async Task<ActionResult<GenralResponce>> RequestService([FromBody] ServiceRequestDto requstServiceDto)
        {
            await _bookingService.RequstService(requstServiceDto);
            return new GenralResponce { IsSuccess = true, Data = "Service Added Successfully" };
        }
        [HttpGet("GetOrderedServices")]
        public async Task<ActionResult<GenralResponce>> GetOrderedServices(string BookingId)
        {
          var x=  await _bookingService.RequstedServices(BookingId);
            return new GenralResponce { IsSuccess = true, Data = x };
        }
    }
}
