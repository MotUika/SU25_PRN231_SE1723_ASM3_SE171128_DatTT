using MyDNA.Repositories.DatTT;
using MyDNA.Repositories.DatTT.ModelExtensions;
using MyDNA.Repositories.DatTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDNA.Services.DatTT
{
    //public interface IFeedBackRatingDatTTService 
    //{ 
    //}
    public class FeedBackRatingDatTTService : IFeedBackRatingDatTTService
    {
        /*        private readonly FeedBackRatingDatTTRepository _feedBackRatingDatTTRepositoryRepository;
        */
        private readonly IUnitOfWork _unitOfWork;

        public FeedBackRatingDatTTService() => _unitOfWork = new UnitOfWork();
        /*public FeedBackRatingDatTTService(FeedBackRatingDatTTRepository feedBackRatingDatTTRepositoryRepository)
        {
            _feedBackRatingDatTTRepositoryRepository = feedBackRatingDatTTRepositoryRepository;
        }*/

        public async Task<int> CreateAsync(FeedBackRatingDatTT feedBackRatingDatTT)
        {
            return await _unitOfWork.FeedBackRatingDatTTRepository.CreateAsync(feedBackRatingDatTT);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var feedBackRating = await _unitOfWork.FeedBackRatingDatTTRepository.GetByIdAsync(id);
            return await _unitOfWork.FeedBackRatingDatTTRepository.RemoveAsync(feedBackRating);
        }

        public async Task<List<FeedBackRatingDatTT>> GetAllAsync()
        {
            return await _unitOfWork.FeedBackRatingDatTTRepository.GetAllAsync();
        }

        public async Task<PaginationResult<List<FeedBackRatingDatTT>>> GetAllWithPagingAsync(int currentPage, int pageSize)
        {
            return await _unitOfWork.FeedBackRatingDatTTRepository.GetAllWithPagingAsync(currentPage, pageSize);
        }

        public async Task<FeedBackRatingDatTT> GetByIdAsync(int id)
        {
            return await _unitOfWork.FeedBackRatingDatTTRepository.GetByIdAsync(id);
        }

        public async Task<List<FeedBackRatingDatTT>> SearchAsync(string title, decimal amount, string serviceName)
        {
            return await _unitOfWork.FeedBackRatingDatTTRepository.SearchAsync(title, amount, serviceName);
        }

        public async Task<PaginationResult<List<FeedBackRatingDatTT>>> SearchWithPagingAsync(string title, decimal amount, string serviceName, int currentPage, int pageSize)
        {
            return await _unitOfWork.FeedBackRatingDatTTRepository.SearchWithPagingAsync(title, amount, serviceName, currentPage, pageSize);
        }
        public async Task<PaginationResult<List<FeedBackRatingDatTT>>> SearchWithAsync(SearchFeedBackRatingRequest searchRequest)
        {
            var feedBackRating = await _unitOfWork.FeedBackRatingDatTTRepository.SearchWithAsync(searchRequest);

            return feedBackRating ??new PaginationResult<List<FeedBackRatingDatTT>>();
        }


        public async Task<int> UpdateAsync(FeedBackRatingDatTT feedBackRatingDatTT)
        {
            return await _unitOfWork.FeedBackRatingDatTTRepository.UpdateAsync(feedBackRatingDatTT);
        }
    }
}
