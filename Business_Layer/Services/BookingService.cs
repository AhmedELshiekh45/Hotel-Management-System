using AutoMapper;
using Business_Layer.DTOS;
using DataAccess.DTOS;
using DataAccess.UOF;
using DataAccessLayer.Constants;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class BookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task AddAsync(BookingDto dto)
        {
            var booking = _mapper.Map<Booking>(dto);
            await _unitOfWork.BookinRepo.AddAsync(booking);
            await _unitOfWork.CompleteAsync();
        }
        public async Task EditAsync(BookingDto dto)
        {
            var booking = await _unitOfWork.BookinRepo.GetByIdAsync(dto.Id);
            booking.CheckOutDate = dto.CheckOutDate;
            booking.CheckInDate = dto.CheckInDate;
            booking.RoomId = dto.RoomId;
            booking.GustId = dto.GustId;
            booking.Stautes = dto.Stautes;

            await _unitOfWork.CompleteAsync();
        }


        public async Task<IEnumerable<BookingDto>> GetAllAsync()
        {
            var x = await _unitOfWork.BookinRepo.GetAllAsync();
            var bookings = x.Select(b => new BookingDto
            {
                Id = b.Id,

                CheckInDate = b.CheckInDate
                ,
                CheckOutDate = b.CheckOutDate,
                Stautes = b.Stautes,
                GustId = b.GustId,
                RoomId = b.RoomId,
                Gust = new UserDto
                {
                    Id = b.Gust.Id,
                    UserName = b.Gust.UserName
                },
                Room = new RoomDto
                {
                    Id = b.Room.Id,
                    RoomNumber = b.Room.RoomNumber,
                    Type = b.Room.Type,
                    Price = b.Room.Price
                }

            });
            return bookings;
        }

        public async Task DeleteAsync(string id)
        {
            var room = await _unitOfWork.BookinRepo.GetByIdAsync(id);
            _unitOfWork.BookinRepo.Delete(room);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<dynamic> GetRoomDeatils(string id)
        {
            var roomdto = await _unitOfWork.BookinRepo.GetByIdAsync(id);
            if (roomdto != null)
            {

                var x = new BookingDto
                {
                    Id = roomdto.Id,

                    CheckInDate = roomdto.CheckInDate
                  ,
                    CheckOutDate = roomdto.CheckOutDate,
                    Stautes = roomdto.Stautes,
                    GustId = roomdto.GustId,
                    RoomId = roomdto.RoomId,
                    Gust = new UserDto
                    {
                        Id = roomdto.Gust.Id,
                        UserName = roomdto.Gust.UserName
                    },
                    Room = new RoomDto
                    {
                        Id = roomdto.Room.Id,
                        RoomNumber = roomdto.Room.RoomNumber,
                        Type = roomdto.Room.Type,
                        Price = roomdto.Room.Price
                    }

                };
                return x;
            }
            return "Not Found";
        }


        public async Task RequstService(ServiceRequestDto requstServiceDto)
        {
            var service = _mapper.Map<ServiceRequest>(requstServiceDto);
            service.Satutes = RequstServicesEnum.Requested.ToString();
            await _unitOfWork.RequestRepo.AddAsync(service);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<IEnumerable<ServiceRequestDto>> RequstedServices(string BookingId)
        {
            var services = _mapper.Map<IEnumerable<ServiceRequestDto>>(await _unitOfWork.RequestRepo.GetBookingRequstsAsync(BookingId));

            return services;
        }

    }
}
