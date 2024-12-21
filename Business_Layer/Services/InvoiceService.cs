using AutoMapper;
using DataAccess.DTOS;
using DataAccess.UOF;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class InvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task AddAsync(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            invoice.TotalAmount = await CalculateTotalAmount(invoiceDto.BookingId);
            await _unitOfWork.InvoiceRepo.AddAsync(invoice);
            await _unitOfWork.CompleteAsync();
        }
        public async Task EditAsync(InvoiceDto invoiceDto)
        {
            var invoice = await _unitOfWork.InvoiceRepo.GetByIdAsync(invoiceDto.Id);
            invoice = _mapper.Map<Invoice>(invoiceDto);
            await _unitOfWork.CompleteAsync();
        }


        public async Task DeleteAsync(string invoiceid)
        {
            var invoice = await _unitOfWork.InvoiceRepo.GetByIdAsync(invoiceid);
             _unitOfWork.InvoiceRepo.Delete(invoice);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            var x = await _unitOfWork.InvoiceRepo.GetAllAsync();
            var items = x.Select(p => new
            {
                InvoiceId = p.Id,
                BookingId = p.BookingId,
                BookingCheckInDate = p.Booking.CheckInDate,
                BookingCheckOutDate = p.Booking.CheckOutDate,
                TotalAmount = p.TotalAmount,
                GustName = p.Booking.Gust.FirstName + p.Booking.Gust.LastName,
                RoomNumber = p.Booking.Room.RoomNumber,
                Services = p.Booking.ServiceRequests.Select(p => new
                {
                    ServiceName = p.Service.Name,
                    ServicePrice = p.Service.Price,

                }).ToList()

            });
            return items;
        }

        private async Task<float> CalculateTotalAmount(string bookingId)
        {
            var x = await _unitOfWork.BookinRepo.GetByIdAsync(bookingId);
            float totalAmount = 0;
            totalAmount += x.Room.Price;
            foreach (var item in x.ServiceRequests)
            {
                totalAmount += item.Service.Price;
            }
            return totalAmount;
        }
        public async Task<dynamic> GetByIdAsync(string InvoiceId)
        {
            var x = await _unitOfWork.InvoiceRepo.GetByIdAsync(InvoiceId);
            var item = new
            {
                InvoiceId = x.Id,
                BookingId = x.BookingId,
                BookingCheckInDate = x.Booking.CheckInDate,
                BookingCheckOutDate = x.Booking.CheckOutDate,
                TotalAmount = x.TotalAmount,
                GustName = x.Booking.Gust.FirstName + x.Booking.Gust.LastName,
                RoomNumber = x.Booking.Room.RoomNumber,
                Services = x.Booking.ServiceRequests.Select(p => new
                {
                    ServiceName = p.Service.Name,
                    ServicePrice = p.Service.Price,

                }).ToList()

            };
            return item;

        }
    }
}
