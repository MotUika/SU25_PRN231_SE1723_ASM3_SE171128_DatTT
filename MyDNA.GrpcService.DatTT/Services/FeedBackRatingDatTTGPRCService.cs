using Grpc.Core;
using MyDNA.GrpcService.DatTT.Protos;
using MyDNA.Repositories.DatTT.Models;
using MyDNA.Services.DatTT;
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
    }
}
