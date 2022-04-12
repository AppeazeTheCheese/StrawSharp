using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using StrawSharp;
using StrawSharp.Helpers;
using StrawSharp.Models;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args) => Start().GetAwaiter().GetResult();

        static async Task Start()
        {
            var client = new StrawPollClient(/* Your API Key (if you have one) */);

            // Upload Image
            var imageName = "TestImage.png";
            var imagePath = Path.Combine(AppContext.BaseDirectory, imageName);
            PollMedia uploadMediaResponse;
            await using (var file = File.OpenRead(imagePath))
            {
                uploadMediaResponse = await client.UploadMediaAsync(imageName, file);
            }

            // Create Poll
            var poll = new PollBuilder()
                .WithTitle("Test")
                .WithDescription("StrawSharp Test")
                .Private()
                .MultipleChoice()
                .WithBorderTableColor(Color.Red)
                .WithMedia(uploadMediaResponse)
                .WithOptions("Test 1", "Test 2", "Test 3")
                .Build();

            var createPollResponse = await client.CreatePollAsync(poll);

            // Get Poll
            var getPollResponse = await client.GetPollAsync(createPollResponse.Id);

            // Delete Poll
            var deletePollResponse = await client.DeletePollAsync(getPollResponse.Id);
            Console.Read();
        }
    }
}
