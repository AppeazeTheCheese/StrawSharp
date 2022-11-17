using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using StrawSharp;
using StrawSharp.Builders;
using StrawSharp.Models.EnumValues;
using StrawSharp.Models.PollModels;

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
            var imagePath = Path.Combine(AppContext.BaseDirectory, "Media", imageName);
            PollMedia uploadMediaResponse;
            await using (var file = File.OpenRead(imagePath))
            {
                uploadMediaResponse = await client.UploadMediaAsync(imageName, file);
            }

            //Create Poll
            var poll = PollBuilder
                .ForMultipleChoicePoll()
                .WithTitle("Test")
                .WithDescription("StrawSharp Test")
                .WithDeadline(DateTime.Now + TimeSpan.FromMinutes(2))
                .WithMediaId(uploadMediaResponse.Id)
                .WithTextOptions("Test 1", "Test 2", "Test 3")
                .Build();

            var createdPoll = await client.CreatePollAsync(poll);
            createdPoll.Config.Deadline = null;

            // Update Poll
            var updatedPoll = await client.UpdatePollAsync(createdPoll);

            // Get Poll
            var getPollResponse = await client.GetPollAsync(updatedPoll.Id);

            // Delete Poll
            await client.DeletePollAsync(getPollResponse.Id);
            Console.Read();
        }
    }
}
