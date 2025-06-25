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
    public class ServiceDatTTRepository : GenericRepository<ServiceDatTT>
    {
        public ServiceDatTTRepository() => _context ??= new DBContext.SU25_PRN231_SE1723_G1_MyDNAContext();
        public ServiceDatTTRepository(SU25_PRN231_SE1723_G1_MyDNAContext context) => _context = context;
    }
}
