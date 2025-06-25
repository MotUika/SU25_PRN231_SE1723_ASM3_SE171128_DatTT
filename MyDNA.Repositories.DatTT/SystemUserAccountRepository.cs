using Microsoft.EntityFrameworkCore;
using MyDNA.Repositories.DatTT.Basic;
using MyDNA.Repositories.DatTT.DBContext;
using MyDNA.Repositories.DatTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDNA.Repositories.DatTT
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() => _context ??= new DBContext.SU25_PRN231_SE1723_G1_MyDNAContext();
        public SystemUserAccountRepository(SU25_PRN231_SE1723_G1_MyDNAContext context) => _context = context;

        public async Task<SystemUserAccount> GetSystemUserAsync(string userName, string password)
        {
            return await _context.SystemUserAccount.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive == true);

            //var userAccount = await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive == true);

            //var userAccount = await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Phone == userName && u.Password == password);
            //var userAccount = await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.EmployeeCode == userName && u.Password == password && u.IsActive == true);
        }
    }
}
