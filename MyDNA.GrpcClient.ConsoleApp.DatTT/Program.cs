// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using MyDNA.GrpcService.DatTT.Protos;

using var channel = GrpcChannel.ForAddress("https://localhost:7244");

var clientFeedBackGRPC = new FeedBackRatingDatTTGRPC.FeedBackRatingDatTTGRPCClient(channel);

Console.WriteLine("\r\nclientFeedBackGRPC.GetAllAsync(EmptyRequest):");
var feedBackRating = clientFeedBackGRPC.GetAllAsync(new EmptyRequest() { });
if (feedBackRating != null && feedBackRating.Items.Count > 0)
{
    foreach (var item in feedBackRating.Items)
    {
        Console.WriteLine(string.Format("{0} - {1}", item.FeedBackRatingDatTtid, item.WriterName));
    }
}

Console.WriteLine("\r\nclient.GetByIdAsync(FeedBackRatingRequest={1}):");
var one = clientFeedBackGRPC.GetByIdAsync(new FeedBackRatingRequest { FeedBackRatingDatTtid = 3 });
Console.WriteLine($"{one.FeedBackRatingDatTtid} - {one.WriterName}");
