using MyDNA.Repositories.DatTT;
using MyDNA.Repositories.DatTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDNA.Services.DatTT
{
    public class ServiceDatTTService
    {
        /*        private readonly ServiceDatTTRepository _serviceDatTTRepositoryRepository;
        */
        private readonly IUnitOfWork _unitOfWork;

        public ServiceDatTTService() => _unitOfWork ??= new UnitOfWork();
        public async Task<List<ServiceDatTT>> GetAllAsync()
        {
            return await _unitOfWork.ServiceDatTTRepository.GetAllAsync();
        }

        public async Task<int> CreateAsync(ServiceDatTT serviceDatTT)
        {
            return await _unitOfWork.ServiceDatTTRepository.CreateAsync(serviceDatTT);
        }

        public async Task<int> UpdateAsync(ServiceDatTT serviceDatTT)
        {
            return await _unitOfWork.ServiceDatTTRepository.UpdateAsync(serviceDatTT);
        }
    }
}
