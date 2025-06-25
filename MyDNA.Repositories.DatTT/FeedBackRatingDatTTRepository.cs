using Microsoft.EntityFrameworkCore;
using MyDNA.Repositories.DatTT.Basic;
using MyDNA.Repositories.DatTT.DBContext;
using MyDNA.Repositories.DatTT.ModelExtensions;
using MyDNA.Repositories.DatTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDNA.Repositories.DatTT
{
    public class FeedBackRatingDatTTRepository: GenericRepository<FeedBackRatingDatTT>
    {
        public FeedBackRatingDatTTRepository() => _context ??= new DBContext.SU25_PRN231_SE1723_G1_MyDNAContext();
        public FeedBackRatingDatTTRepository(SU25_PRN231_SE1723_G1_MyDNAContext context) => _context = context;
        public async Task<PaginationResult<List<FeedBackRatingDatTT>>> GetAllWithPagingAsync(int currentPage, int pageSize)
        {
            var FeedBackRating = await this.GetAllAsync();

            //// Paging
            var totalItems = FeedBackRating.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            FeedBackRating = FeedBackRating.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var result = new PaginationResult<List<FeedBackRatingDatTT>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = currentPage,
                PageSize = pageSize,
                Items = FeedBackRating
            };

            return result;
        }
/*        public async Task<List<FeedBackRatingDatTT>> GetAllAsync()
        {
            var feedBackRatingDatTTs =  await _context.FeedBackRatingDatTT.Include(d => d.ServiceDatTt).ToListAsync();
            return feedBackRatingDatTTs ?? new List<FeedBackRatingDatTT>();
        }*/
        public async Task<FeedBackRatingDatTT> GetByIdAsync(int code)
        {
            var feedBackRatingDatTTs = await _context.FeedBackRatingDatTT
                .Include(d => d.ServiceDatTt)
                .FirstOrDefaultAsync(d => d.FeedBackRatingDatTtid == code);

            return feedBackRatingDatTTs ?? new FeedBackRatingDatTT();
        }

        public async Task<List<FeedBackRatingDatTT>> SearchAsync(string title, decimal amount,string serviceName)
        {
            var feedBackRatingDatTTs = await _context.FeedBackRatingDatTT.Include(d => d.ServiceDatTt)
                .Where(d => (d.Title.Contains(title) || string.IsNullOrEmpty(title))
                && (d.Rating == amount || amount == 0 || amount == null)
                && (d.ServiceDatTt.ServiceName.Contains(serviceName) || string.IsNullOrEmpty(serviceName)))
                .ToListAsync();

            return feedBackRatingDatTTs ?? new List<FeedBackRatingDatTT>();
        }

        public async Task<PaginationResult<List<FeedBackRatingDatTT>>> SearchWithPagingAsync(string title, decimal amount, string serviceName, int currentPage, int pageSize)
        {
            var FeedBackRating = await this.SearchAsync(title, amount, serviceName);

            //// Paging
            var totalItems = FeedBackRating.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            FeedBackRating = FeedBackRating.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var result = new PaginationResult<List<FeedBackRatingDatTT>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = currentPage,
                PageSize = pageSize,
                Items = FeedBackRating
            };

            return result;
        }
        public async Task<PaginationResult<List<FeedBackRatingDatTT>>> SearchWithAsync(SearchFeedBackRatingRequest searchRequest)
        {
            var FeedBackRating = await this.SearchAsync(searchRequest.title, searchRequest.amount.GetValueOrDefault(), searchRequest.serviceName);

            //// Paging
            var totalItems = FeedBackRating.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / searchRequest.PageSize.GetValueOrDefault());

            FeedBackRating = FeedBackRating.Skip((searchRequest.CurrentPage.GetValueOrDefault() - 1) * 
                searchRequest.PageSize.GetValueOrDefault()).Take(searchRequest.PageSize.GetValueOrDefault()).ToList();

            var result = new PaginationResult<List<FeedBackRatingDatTT>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = searchRequest.CurrentPage.GetValueOrDefault(),
                PageSize = searchRequest.PageSize.GetValueOrDefault(),
                Items = FeedBackRating
            };

            return result;
        }
    }
}
