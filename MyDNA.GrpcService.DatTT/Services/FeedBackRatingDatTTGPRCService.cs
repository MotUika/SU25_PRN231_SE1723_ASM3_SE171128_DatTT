using Grpc.Core;
using MyDNA.GrpcService.DatTT.Protos;
using MyDNA.Repositories.DatTT.Models;
using MyDNA.Services.DatTT;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyDNA.GrpcService.DatTT.Services
{
    public class FeedBackRatingDatTTGPRCService : FeedBackRatingDatTTGRPC.FeedBackRatingDatTTGRPCBase
    {
        private readonly IServiceProviders _serviceProviders;
        public FeedBackRatingDatTTGPRCService(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders;
        public override async Task<FeedBackRatingResponseList> GetAllAsync(EmptyRequest request, ServerCallContext context)
        {
            var result = new FeedBackRatingResponseList();

            try
            {
                var feedBackRatings = await _serviceProviders.FeedBackRatingDatTTService.GetAllAsync();

                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


                var feedBackRatingJsonString = JsonSerializer.Serialize(feedBackRatings, opt);


                var items = JsonSerializer.Deserialize<List<FeedBackRatingResponse>>(feedBackRatingJsonString, opt);


                result.Items.AddRange(items);
            }
            catch (Exception ex) { }

            return result;
        }

        public override async Task<FeedBackRatingResponse> GetByIdAsync(FeedBackRatingRequest request, ServerCallContext context)
        {
            var result = new FeedBackRatingResponse();

            try
            {
                var feedBackRating = await _serviceProviders.FeedBackRatingDatTTService.GetByIdAsync(request.FeedBackRatingDatTtid);

                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

                var feedBackRatingJsonString = JsonSerializer.Serialize(feedBackRating, opt);

                result = JsonSerializer.Deserialize<FeedBackRatingResponse>(feedBackRatingJsonString, opt);
            }
            catch (Exception ex) { }

            return result;
        }
        public override async Task<MutationResult> CreateAsync(FeedBackRatingRequestUpdate request, ServerCallContext context)
        {
            try
            {

                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


                var protoJsonString = JsonSerializer.Serialize(request, opt);


                var item = JsonSerializer.Deserialize<MyDNA.Repositories.DatTT.Models.FeedBackRatingDatTT>(protoJsonString, opt);

                var result = await _serviceProviders.FeedBackRatingDatTTService.CreateAsync(item);

                return new MutationResult() { Result = result };
            }
            catch (Exception ex) { }

            return new MutationResult() { Result = 0 };
        }
        public override async Task<MutationResult> UpdateAsync(FeedBackRatingRequestUpdate request, ServerCallContext context)
        {
            try
            {

                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


                var protoJsonString = JsonSerializer.Serialize(request, opt);


                var item = JsonSerializer.Deserialize<MyDNA.Repositories.DatTT.Models.FeedBackRatingDatTT>(protoJsonString, opt);

                var result = await _serviceProviders.FeedBackRatingDatTTService.UpdateAsync(item);

                return new MutationResult() { Result = result };
            }
            catch (Exception ex) { }

            return new MutationResult() { Result = 0 };
        }
        public override async Task<MutationResult> DeleteAsync(FeedBackRatingRequest request, ServerCallContext context)
        {
            try
            {
                var result = await _serviceProviders.FeedBackRatingDatTTService.DeleteAsync(request.FeedBackRatingDatTtid);

                return new MutationResult() { Result = result ? 1 : 0 };

            }
            catch (Exception ex) { }

            return new MutationResult() { Result = 0 };
        }
    }
}
