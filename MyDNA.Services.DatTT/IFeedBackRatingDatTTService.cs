using MyDNA.Repositories.DatTT.ModelExtensions;
using MyDNA.Repositories.DatTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDNA.Services.DatTT
{
    public interface IFeedBackRatingDatTTService
    {
        Task<List<FeedBackRatingDatTT>> GetAllAsync();
        Task<FeedBackRatingDatTT> GetByIdAsync(int id);
        Task<List<FeedBackRatingDatTT>> SearchAsync(string title, decimal amount, string serviceName);
        Task<PaginationResult<List<FeedBackRatingDatTT>>> GetAllWithPagingAsync(int currentPage, int pageSize);
        Task<PaginationResult<List<FeedBackRatingDatTT>>> SearchWithPagingAsync(string title, decimal amount, string serviceName, int currentPage, int pageSize);
        Task<PaginationResult<List<FeedBackRatingDatTT>>> SearchWithAsync(SearchFeedBackRatingRequest searchRequest);
        Task<int> CreateAsync(FeedBackRatingDatTT feedBackRatingDatTT);
        Task<int> UpdateAsync(FeedBackRatingDatTT feedBackRatingDatTT);
        Task<bool> DeleteAsync(int id);
    }
}
