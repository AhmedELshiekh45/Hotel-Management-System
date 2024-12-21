using Business_Layer.DTOS;
using Business_Layer.Services;
using DataAccess.Constants;
using DataAccess.Repositories.RoomRepos;
using DataAccess.UOF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin,Emplyee,Gust")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;
       

        public RoomController(RoomService roomService)
        {
            this._roomService = roomService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<GenralResponce>> GetAll()
        {
            var rooms = await _roomService.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("RoomDetials")]
        public async Task<ActionResult<GenralResponce>> GetById(string id)
        {
            return new GenralResponce { Data = await _roomService.GetByIdAsync(id) };
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<GenralResponce>> Delete(string id)
        {
            await _roomService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("Add")]
        public async Task<ActionResult<GenralResponce>> Add(RoomDto roomDto)
        {
            if (ModelState.IsValid)
            {
                
                await _roomService.AddAsync(roomDto);
                return  CreatedAtAction("GetById",roomDto);
            }
            return Ok(ModelState);
        }


        [HttpPut("Edit")]
        public async Task<ActionResult<GenralResponce>> Edit(RoomDto roomDto)
        {
            await _roomService.EditAsyc(roomDto);
            return NoContent();
        }

    }
}
