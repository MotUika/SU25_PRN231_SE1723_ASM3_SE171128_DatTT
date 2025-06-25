using MyDNA.Repositories.DatTT.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDNA.Repositories.DatTT
{
    public interface IUnitOfWork : IDisposable
    {
        SystemUserAccountRepository SystemUserAccountRepository { get; }
        FeedBackRatingDatTTRepository FeedBackRatingDatTTRepository { get; }
        ServiceDatTTRepository ServiceDatTTRepository { get; }
        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SU25_PRN231_SE1723_G1_MyDNAContext _context;
        private SystemUserAccountRepository _systemUserAccountRepository;
        private FeedBackRatingDatTTRepository _feedBackRatingDatTTRepository;
        private ServiceDatTTRepository _serviceDatTTRepository;

        public UnitOfWork() => _context ??= new SU25_PRN231_SE1723_G1_MyDNAContext();

        public SystemUserAccountRepository SystemUserAccountRepository
        {
            get { return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context); }
        }
        public FeedBackRatingDatTTRepository FeedBackRatingDatTTRepository
        {
            get { return _feedBackRatingDatTTRepository ??= new FeedBackRatingDatTTRepository(_context); }
        }
        public ServiceDatTTRepository ServiceDatTTRepository
        {
            get { return _serviceDatTTRepository ??= new ServiceDatTTRepository(_context); }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
}
