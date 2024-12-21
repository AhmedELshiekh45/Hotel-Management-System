using AutoMapper;
using Business_Layer.DTOS;
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
    public class ServicesService
    {
        public IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private Service service;

        public ServicesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this.service = new Service();
        }

        public async Task AddAsync(ServiceDto Dto)
        {
            service = _mapper.Map<Service>(Dto);
           // service.Id = Guid.NewGuid().ToString();
            await _unitOfWork.ServiceRepo.AddAsync(service);
            await _unitOfWork.CompleteAsync();
        }

        public async Task EditAsyc(ServiceDto dto)
        {
            service = await _unitOfWork.ServiceRepo.GetByIdAsync(dto.Id);

            service.Price = dto.Price;
            service.Description = dto.Description;
            service.Name = dto.Name;
            service.Id = dto.Id;

            await _unitOfWork.CompleteAsync();
        }
        public async Task<IEnumerable<ServiceDto>> GetAllAsync()
        {

            var services = _mapper.Map<IEnumerable<ServiceDto>>(await _unitOfWork.ServiceRepo.GetAllAsync());
           
            return services;
        }
        public async Task DeleteAsync(string id)
        {
            var room = await _unitOfWork.ServiceRepo.GetByIdAsync(id);
            _unitOfWork.ServiceRepo.Delete(room);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<ServiceDto> GetByIdAsync(string id)
        {
            var service = _mapper.Map<ServiceDto>(await _unitOfWork.ServiceRepo.GetByIdAsync(id));
            
            return service;
        }
    }
}
