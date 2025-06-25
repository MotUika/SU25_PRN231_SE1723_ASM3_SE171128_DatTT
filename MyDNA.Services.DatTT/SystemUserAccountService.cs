using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MyDNA.Repositories.DatTT;
using MyDNA.Repositories.DatTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDNA.Services.DatTT
{
    public class SystemUserAccountService
    {
        /*        private readonly SystemUserAccountRepository _systemUserAccountRepository;
        */
        private readonly IUnitOfWork _unitOfWork;

        public SystemUserAccountService() => _unitOfWork ??= new UnitOfWork();

        public async Task<SystemUserAccount> GetUserAccountAsync(string username,string password)
        {
            return await _unitOfWork.SystemUserAccountRepository.GetSystemUserAsync(username, password);
        }
    }
}
