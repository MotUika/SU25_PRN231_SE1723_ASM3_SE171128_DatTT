// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using MyDNA.GrpcClient.ConsoleApp.DatTT.Protos;

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
var one = clientFeedBackGRPC.GetByIdAsync(new FeedBackRatingRequest { FeedBackRatingDatTtid =  });
Console.WriteLine($"{one.FeedBackRatingDatTtid} - {one.WriterName}");

var createResponse = clientFeedBackGRPC.CreateAsync(new FeedBackRatingRequestUpdate
{
    ServiceDatTtid = 1,
    Rating = 5,
    WriterName = "John Doe",
    Title = "Excellent!",
    Content = "Very satisfied.",
    IsVisible = true,
    UpdatedAt = DateTime.UtcNow.ToString("o"),
    FeedbackScore = 100
});
Console.WriteLine($"\nCreateAsync: Result = {createResponse.Result}");

var updateResponse = clientFeedBackGRPC.UpdateAsync(new FeedBackRatingRequestUpdate
{
    FeedBackRatingDatTtid = 23,
    ServiceDatTtid = 1,
    Rating = 4,
    WriterName = "John Updated",
    Title = "Still Good",
    Content = "A bit slower, but okay.",
    IsVisible = true,
    UpdatedAt = DateTime.UtcNow.ToString("o"),
    FeedbackScore = 85
});
Console.WriteLine($"\nUpdateAsync: Result = {updateResponse.Result}");

// DELETE
var deleteResponse = clientFeedBackGRPC.DeleteAsync(new FeedBackRatingRequest { FeedBackRatingDatTtid = 1 });
Console.WriteLine($"\nDeleteAsync: Result = {deleteResponse.Result}");
