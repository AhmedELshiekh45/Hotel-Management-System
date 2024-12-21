using AutoMapper;
using Business_Layer.DTOS;
using DataAccess.UOF;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class RoomService
    {
        public IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private Room room;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this.room = new Room();
        }

        public async Task AddAsync(RoomDto roomDto)
        {
            room = _mapper.Map<Room>(roomDto);
            await _unitOfWork.RoomRepo.AddAsync(room);
            await _unitOfWork.CompleteAsync();
        }

        public async Task EditAsyc(RoomDto dto)
        {
            room = await _unitOfWork.RoomRepo.GetByIdAsync(dto.Id);

            room.RoomNumber = dto.RoomNumber;
            room.Status = dto.Status;
            room.Price = dto.Price;
            room.Type = dto.Type;

            await _unitOfWork.CompleteAsync();
        }
        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {

            var rooms = _mapper.Map<IEnumerable<RoomDto>>(await _unitOfWork.RoomRepo.GetAllAsync());
            return rooms;
        }
        public async Task DeleteAsync(string id)
        {
            var room = await _unitOfWork.RoomRepo.GetByIdAsync(id);
            _unitOfWork.RoomRepo.Delete(room);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<RoomDto> GetByIdAsync(string id)
        {
            var room = _mapper.Map<RoomDto>(await _unitOfWork.RoomRepo.GetByIdAsync(id));
            return room;
        }

    }
}
