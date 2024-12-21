using Business_Layer.DTOS;
using Business_Layer.Services;
using DataAccess.Constants;
using DataAccess.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServicesService _services;

        public ServiceController(ServicesService services)
        {
            this._services = services;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<GenralResponce>> GetAll()
        {
            return new GenralResponce { IsSuccess=true, Data = await _services.GetAllAsync() };
        }

        [HttpGet("GetDeatils")]
        public async Task<ActionResult<GenralResponce>> GetById(string id)
        {
            return new GenralResponce { IsSuccess=true, Data = await _services.GetByIdAsync(id) };
        }
        [HttpPost("Add")]
        public async Task<ActionResult<GenralResponce>> Add(ServiceDto Dto)
        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(Dto);
                return CreatedAtAction("GetById", Dto);
            }
            return BadRequest(ModelState);
        }
     //   [Authorize(Roles = "Admin,Employee")]
        [HttpPut("Edit")]
        public async Task<ActionResult<GenralResponce>> Edit(ServiceDto Dto)
        {
            if (ModelState.IsValid)
            {
                await _services.EditAsyc(Dto);
                return CreatedAtAction("GetById", Dto);
            }
            return BadRequest(ModelState);
        }

       
        [HttpDelete("Delete")]
        public async Task<ActionResult<GenralResponce>> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                await _services.DeleteAsync(id);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

       
    }
}
